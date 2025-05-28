using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model.Entities;

/// <summary>
/// Users — Зарегистрированные пользователи
/// Хранит данные аккаунтов, которые могут бронировать билеты.
/// </summary>
public class User
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string? Phone { get; set; }

    [Required]
    public string Role { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<Ticket> Tickets { get; set; }

    public ICollection<UserEventCalendar> Calendars { get; set; }
}
