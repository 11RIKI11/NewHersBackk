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
    private readonly TicketService _ticketsServise;

    public AttendeeService(ApplicationDbContext context, IMapper mapper, TicketService ticketService)
    {
        _context = context;
        _mapper = mapper;
        _ticketsServise = ticketService;
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

    public async Task<ServiceResult<AttendeeResponse>> CreateAttendeeAsync(AttendeeAddRequest request)
    {
        //Проверь что посетителя с такими паспортными данными нет
        var attendee = await _context.Attendees
            .FirstOrDefaultAsync(a => a.DocumentNumber == request.DocumentNumber);
        if (attendee == null)
        {
            attendee = _mapper.Map<Attendee>(request);
            attendee.CreatedAt = DateTime.UtcNow;
            await _context.Attendees.AddAsync(attendee);
            await _context.SaveChangesAsync();
        }

        UserAttendee? userAttendee = null;
        if (request.UserId != null)
            userAttendee = await _context.UserAttendees.
                FirstOrDefaultAsync(ua => ua.UserId == request.UserId &&
                ua.AttendeeId == attendee.Id);

        if (userAttendee == null)
        {
            userAttendee = new UserAttendee
            {
                UserId = request.UserId.Value,
                AttendeeId = attendee.Id
            };
        }

        var ticket = await _context.Tickets
            .FirstOrDefaultAsync(t => t.Id == request.TicketId);
        if (ticket == null)
            return ServiceResult<AttendeeResponse>.Failure("Билет с таким Id не найден", 404);
        if (request.UserId != null)
        {
            ServiceResult<Guid> reserveResult = await _ticketsServise.ReserveTicketAsync(request.UserId.Value, ticket.EventId);
            if (!reserveResult.IsSuccess)
                return ServiceResult<AttendeeResponse>.Failure("Не удалось зарезервировать билет. " + reserveResult.Error.ErrorMessage, reserveResult.Error.StatusCode);
            ticket.AttendeeId = attendee.Id;
        }

        var mappingAttendee = _mapper.Map<AttendeeResponse>(attendee);
        return ServiceResult<AttendeeResponse>.Success(mappingAttendee);
    }

    public async Task<ServiceResult<SearchResultResponse<AttendeeResponse>>> GetAttendeesByUserByEventAsync(Guid userId, Guid eventId, AttendeeSearchRequest request)
    {
        var ticketAttendees = await _context.Tickets
            .Where(t => t.EventId == eventId && t.BuyerId == userId)
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

