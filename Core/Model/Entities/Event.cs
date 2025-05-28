using System.ComponentModel.DataAnnotations;

namespace Core.Model.Entities;

/// <summary>
/// Events — Экскурсии/мероприятия
/// Список доступных для бронирования событий.
/// </summary>
public class Event
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int TicketsCount { get; set; }

    [Required]
    public bool IsActive { get; set; }

    [Required] public string Tag { get; set; } = string.Empty; // e.g., "excursion", "event"

    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

    //public List<Image> Images { get; set; }
}
