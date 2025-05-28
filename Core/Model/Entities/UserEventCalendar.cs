using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model.Entities;

public class UserEventCalendar
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    public Event Event { get; set; }

    public string? Note { get; set; }

    public DateTime? ReminderTime { get; set; }
}
