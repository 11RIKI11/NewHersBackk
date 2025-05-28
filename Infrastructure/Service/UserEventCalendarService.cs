using AutoMapper;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.User;
using Core.Model.DTO.UserEventCalendar;
using Core.Model.Entities;
using Core.Results;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class UserEventCalendarService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserEventCalendarService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<SearchResultResponse<UserCalendarEventResponse>>> GetUserEventsByUserIdAsync(Guid userId, PaginationRequest pagination)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            return ServiceResult<SearchResultResponse<UserCalendarEventResponse>>.Failure("User not found.", 404);
        var userEvents = _context.UserEventCalendars.AsQueryable()
            .Include(uec => uec.Event)
            .Where(uec => uec.UserId == userId);
        var total = await userEvents.CountAsync();
        var userEventsList = await userEvents
            .Paginate(pagination.Page, pagination.PageSize)
            .ToListAsync();
        var eventsResponses = _mapper.Map<List<UserCalendarEventResponse>>(userEventsList);

        var result = new SearchResultResponse<UserCalendarEventResponse>
        {
            Items = eventsResponses,
            TotalCount = total
        };
        return ServiceResult<SearchResultResponse<UserCalendarEventResponse>>.Success(result);
    }
    public async Task<ServiceResult<UserCalendarEventResponse>> AddUserCalendarEventAsync(Guid userId, UserCalendarAddEventRequest request)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            return ServiceResult<UserCalendarEventResponse>.Failure("User not found.", 404);
        var usersEvent = new UserEventCalendar
        {
            UserId = userId,
            EventId = request.EventId,
            Note = request.Note,
            ReminderTime = request.ReminderTime
        };
        await _context.UserEventCalendars.AddAsync(usersEvent);
        await _context.SaveChangesAsync();
        var calendar = await _context.UserEventCalendars
            .Include(uec => uec.Event)
            .Include(uec => uec.User)
            .Where(uec => uec.Id == usersEvent.Id)
            .FirstOrDefaultAsync();
        var mappedCalendarEvent = _mapper.Map<UserCalendarEventResponse>(calendar);
        return ServiceResult<UserCalendarEventResponse>.Success(mappedCalendarEvent);
    }

    public async Task<ServiceResult<bool>> RemoveUserCalendarEventAsync(Guid userId, Guid eventId)
    {
        var usersEvent = await _context.UserEventCalendars
            .FirstOrDefaultAsync(uec => uec.UserId == userId && uec.EventId == eventId);
        if (usersEvent == null)
            return ServiceResult<bool>.Failure("Calendar event not found.", 404);
        _context.UserEventCalendars.Remove(usersEvent);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> RemoveUserCalendarEventByIdAsync(Guid id)
    {
        var usersEvent = await _context.UserEventCalendars
            .FirstOrDefaultAsync(uec => uec.Id == id);
        if (usersEvent == null)
            return ServiceResult<bool>.Failure("Calendar event not found.", 404);
        _context.UserEventCalendars.Remove(usersEvent);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> RemoveUserCalendarEventByEventIdAsync(Guid eventId)
    {
        var usersEvent = await _context.UserEventCalendars
            .FirstOrDefaultAsync(uec => uec.EventId == eventId);
        if (usersEvent == null)
            return ServiceResult<bool>.Failure("Calendar event not found.", 404);
        _context.UserEventCalendars.Remove(usersEvent);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> RemoveAllEventsFromCalendarAsync(Guid userId)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
            return ServiceResult<bool>.Failure("User not found.", 404);
        var usersEvents = await _context.UserEventCalendars
            .Where(uec => uec.UserId == userId)
            .ToListAsync();
        if (usersEvents == null || !usersEvents.Any())
            return ServiceResult<bool>.Failure("No calendars found for this user.", 404);
        _context.UserEventCalendars.RemoveRange(usersEvents);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> UpdateUserCalendarEventAsync(Guid userId, Guid eventId, UserCalendarUpdateEventRequest request)
    {
        var usersEvent = await _context.UserEventCalendars
            .FirstOrDefaultAsync(uec => uec.UserId == userId && uec.EventId == eventId);
        if (usersEvent == null)
            return ServiceResult<bool>.Failure("Calendar event not found.", 404);
        usersEvent.Note = request.Note;
        usersEvent.ReminderTime = request.ReminderTime;
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> UpdateUserCalendarEventByIdAsync(Guid id, UserCalendarUpdateEventRequest request)
    {
        var usersEvent = await _context.UserEventCalendars
            .FirstOrDefaultAsync(uec => uec.Id == id);
        if (usersEvent == null)
            return ServiceResult<bool>.Failure("Calendar event not found.", 404);
        usersEvent.EventId = request.EventId;
        usersEvent.Note = request.Note;
        usersEvent.ReminderTime = request.ReminderTime;
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }
}

