using Core.Model.DTO.User;

namespace Core.Model.DTO.UserEventCalendar;

public class UserCalendarResponse
{
    public UserResponse User { get; set; } = null!;
    public List<UserCalendarEventResponse>? Events { get; set; } = new();
}

