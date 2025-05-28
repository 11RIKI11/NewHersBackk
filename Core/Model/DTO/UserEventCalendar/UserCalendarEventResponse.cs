using Core.Model.DTO.Event;

namespace Core.Model.DTO.UserEventCalendar;

public class UserCalendarEventResponse
{
    public Guid Id { get; set; }
    public EventResponse Event { get; set; }
    public string? Note { get; set; } = null;
    public DateTime? ReminderTime { get; set; } = null;
}

