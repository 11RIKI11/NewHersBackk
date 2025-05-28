
using System.ComponentModel.DataAnnotations;
using Core.Enums;

namespace Core.Model.Entities;

public class Attendee
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public string DocumentType { get; set; }

    [Required]
    public string DocumentNumber { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
