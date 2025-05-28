using System.ComponentModel.DataAnnotations;
using Core.ValidateAttribute.Date;

namespace Core.Model.DTO.UserEventCalendar;

public class UserCalendarAddEventRequest
{
    [Required]
    public Guid EventId { get; set; }
    [StringLength(500, ErrorMessage = "Note cannot exceed 500 characters.")]
    public string? Note { get; set; } = null;
    
    [DateValidation(AllowFutureDate = true)]
    public DateTime? ReminderTime { get; set; } = null;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ReminderTime.HasValue && ReminderTime <= DateTime.UtcNow)
        {
            yield return new ValidationResult(
                "Reminder time must be in the future.",
                new[] { nameof(ReminderTime) });
        }
    }
}

