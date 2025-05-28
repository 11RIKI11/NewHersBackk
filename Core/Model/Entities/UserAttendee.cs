using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model.Entities;

public class UserAttendee
{
    [Key]
    public Guid Id { get; set; }
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User? User { get; set; } = null;
    [ForeignKey("Attendee")]
    public Guid AttendeeId { get; set; }
    public Attendee? Attendee { get; set; } = null;
}

