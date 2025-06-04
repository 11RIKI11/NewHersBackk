using AutoMapper;
using Core.Enums;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.User;
using Core.Model.Entities;
using Core.Results;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class AttendeeService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AttendeeService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<AttendeeResponse>> GetAttendeeById(Guid id)
    {
        var attendee = await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);

        if (attendee == null)
            return ServiceResult<AttendeeResponse>.Failure("Посетитель с таким Id не найден", 404);

        return ServiceResult<AttendeeResponse>.Success(_mapper.Map<AttendeeResponse>(attendee));
    }

    public async Task<ServiceResult<SearchResultResponse<AttendeeResponse>>> GetAttendeesAsync(AttendeeSearchRequest request)
    {
        var query = _context.Attendees.AsQueryable();

        if (request.Filter.AttendeeIds.Count > 0)
            query = query.Where(a => request.Filter.AttendeeIds.Contains(a.Id));

        if (!string.IsNullOrEmpty(request.Filter.FullName))
            query = query.Where(a =>
            EF.Functions.ILike(a.FullName, $"{request.Filter.FullName}%") ||
            EF.Functions.ILike(a.FullName, $" %{request.Filter.FullName}")
            );
        if (request.Filter.BirthDateFrom != null)
            query = query.Where(a => a.BirthDate >= request.Filter.BirthDateFrom);
        if (request.Filter.BirthDateTo != null)
            query = query.Where(a => a.BirthDate <= request.Filter.BirthDateTo);
        if (request.Filter.DocType.Count > 0)
        {
            var docTypes = request.Filter.DocType.Select(dt => dt.ToString().ToLower()).ToList();
            query = query.Where(a => docTypes.Contains(a.DocumentType.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.Filter.DocNumber))
            query = query.Where(a => EF.Functions.ILike(a.DocumentNumber, $"{request.Filter.DocNumber}%"));

        query = SortingHelper.ApplySorting(query, request.Sort);

        var total = await query.CountAsync();

        // Пагинация
        var attendees = await query
            .Paginate(request.Pagination.Page, request.Pagination.PageSize)
            .ToListAsync();

        var mappingAttendees = _mapper.Map<List<AttendeeResponse>>(attendees);

        var resultResponse = new SearchResultResponse<AttendeeResponse>
        {
            Items = mappingAttendees,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<AttendeeResponse>>.Success(resultResponse);
    }

    public async Task<ServiceResult<SearchResultResponse<AttendeeResponse>>> GetAttendeesByUserAsync(Guid userId, AttendeeSearchRequest request)
    {
        var attendeesIds = await _context.UserAttendees
            .Where(ua => ua.UserId == userId)
            .Select(ua => ua.AttendeeId)
            .ToListAsync();
        if(attendeesIds.Count == 0)
        {
            return ServiceResult<SearchResultResponse<AttendeeResponse>>.Success(new SearchResultResponse<AttendeeResponse> { TotalCount = 0, Items = [] });
        }
        request.Filter.AttendeeIds = attendeesIds;
        var searchResult = await GetAttendeesAsync(request);
        if (!searchResult.IsSuccess)
            return ServiceResult<SearchResultResponse<AttendeeResponse>>.Failure("Ошибка при поиске: " + searchResult.Error.ErrorMessage, searchResult.Error.StatusCode);

        return ServiceResult<SearchResultResponse<AttendeeResponse>>.Success(searchResult.Data);
    }

    public async Task<ServiceResult<bool>> UpdateAttendeeAsync(Guid id, AttendeeUpdateRequest request)
    {
        var attendee = await _context.Attendees.FirstOrDefaultAsync(u => u.Id == id);

        if (attendee == null)
            return ServiceResult<bool>.Failure("Посетитель с таким Id не найден", 404);

        _mapper.Map(request, attendee);

        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    // Удалить посетителя
    public async Task<ServiceResult<bool>> DeleteAttendeeByIdAsync(Guid id)
    {
        var attendee = await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);

        if (attendee == null)
            return ServiceResult<bool>.Failure("Посетитель с таким Id не найден", 404);

        _context.Attendees.Remove(attendee);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<AttendeeResponse>> CreateAttendeeAsync(Guid userId, AttendeeAddRequest request)
    {
        // Проверь, что посетителя с такими паспортными данными нет
        var userAttendees = await _context.UserAttendees
            .Include(ua => ua.User)
            .Include(ua => ua.Attendee)
            .Where(ua => ua.UserId == userId && ua.Attendee.DocumentNumber == request.DocumentNumber)
            .FirstOrDefaultAsync();
        AttendeeResponse mappingAttendee;
        if (userAttendees != null)
        {
            mappingAttendee = _mapper.Map<AttendeeResponse>(userAttendees.Attendee);
            return ServiceResult<AttendeeResponse>.Success(mappingAttendee);
        }
        var attendee = _mapper.Map<Attendee>(request);
        attendee.CreatedAt = DateTime.UtcNow;
        await _context.Attendees.AddAsync(attendee);
        await _context.SaveChangesAsync();

        // Вынесено в отдельный метод
        var linkResult = await CreateUserAttendeeLinkAsync(userId, attendee.Id);
        if (!linkResult.IsSuccess)
            return ServiceResult<AttendeeResponse>.Failure("Не удалось создать связь пользователь-посетитель");

        mappingAttendee = _mapper.Map<AttendeeResponse>(attendee);
        return ServiceResult<AttendeeResponse>.Success(mappingAttendee);
    }

    public async Task<ServiceResult<List<AttendeeResponse>>> CreateAttendeeRangeAsync(Guid userId, List<AttendeeAddRequest> requests)
    {
        var responses = new List<AttendeeResponse>();
        
        // Получаем все существующие записи по номерам документов
        var documentNumbers = requests.Select(r => r.DocumentNumber).ToList();
        var existingAttendees = await _context.UserAttendees
            .Include(ua => ua.Attendee)
            .Where(ua => ua.UserId == userId && documentNumbers.Contains(ua.Attendee.DocumentNumber))
            .ToListAsync();

        // Обрабатываем существующих посетителей
        foreach (var existing in existingAttendees)
        {
            responses.Add(_mapper.Map<AttendeeResponse>(existing.Attendee));
            requests.RemoveAll(r => r.DocumentNumber == existing.Attendee.DocumentNumber);
        }

        if (!requests.Any())
            return ServiceResult<List<AttendeeResponse>>.Success(responses);

        // Создаем новых посетителей
        var newAttendees = requests.Select(request =>
        {
            var attendee = _mapper.Map<Attendee>(request);
            attendee.CreatedAt = DateTime.UtcNow;
            return attendee;
        }).ToList();

        await _context.Attendees.AddRangeAsync(newAttendees);
        await _context.SaveChangesAsync();

        // Создаем связи пользователь-посетитель
        var userAttendees = newAttendees.Select(attendee => new UserAttendee
        {
            UserId = userId,
            AttendeeId = attendee.Id
        });

        await _context.UserAttendees.AddRangeAsync(userAttendees);
        await _context.SaveChangesAsync();

        // Добавляем новых посетителей в ответ
        responses.AddRange(_mapper.Map<List<AttendeeResponse>>(newAttendees));

        return ServiceResult<List<AttendeeResponse>>.Success(responses);
    }

    private async Task<ServiceResult<bool>> CreateUserAttendeeLinkAsync(Guid userId, Guid attendeeId)
    {
        var userAttendee = await _context.UserAttendees
            .FirstOrDefaultAsync(ua => ua.UserId == userId && ua.AttendeeId == attendeeId);

        if (userAttendee == null)
        {
            userAttendee = new UserAttendee
            {
                UserId = userId,
                AttendeeId = attendeeId
            };
            await _context.UserAttendees.AddAsync(userAttendee);
            await _context.SaveChangesAsync();
        }

        return ServiceResult<bool>.Success(true);
    }

    public async Task<ServiceResult<SearchResultResponse<AttendeeResponse>>> GetAttendeesByUserByEventAsync(Guid userId, Guid eventId, AttendeeSearchRequest request)
    {
        var ticketAttendees = await _context.Tickets
            .Include(t => t.Payment)
            .Where(t => t.EventId == eventId && t.Payment == null ? true : t.Payment.BuyerId == userId)
            .Select(t => t.AttendeeId)
            .ToListAsync();
        var attendees = await _context.Attendees
            .Where(a => ticketAttendees.Contains(a.Id))
            .Select(a => a.Id)
            .ToListAsync();
        if (attendees == null || attendees.Count == 0)
            return ServiceResult<SearchResultResponse<AttendeeResponse>>.Failure("Посетители не найдены", 404);
        request.Filter.AttendeeIds = attendees;
        var searchResult = await GetAttendeesAsync(request);
        return ServiceResult<SearchResultResponse<AttendeeResponse>>.Success(searchResult.Data);
    }
}

