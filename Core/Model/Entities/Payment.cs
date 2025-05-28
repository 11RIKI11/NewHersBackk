using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Model.Entities;

/// <summary>
/// Payments — Платежи через ЮKassa
/// Информация о платежах за один или несколько билетов.
/// </summary>

public class Payment
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("Buyer")]
    public Guid BuyerId { get; set; }
    public User Buyer { get; set; }

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public string Status { get; set; }

    public string QrUrl { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public DateTime? PaidAt { get; set; }
}
