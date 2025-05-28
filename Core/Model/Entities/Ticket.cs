using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;
using Core.Model.Entities;

namespace Core.Model.Entities;

/// <summary>
/// Tickets — Билеты
/// Информация о купленных билетах, включая покупателя и владельца.
/// </summary>
public class Ticket
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("Event")]
    public Guid EventId { get; set; }
    public Event Event { get; set; }

    [ForeignKey("Buyer")]
    public Guid? BuyerId { get; set; }
    public User Buyer { get; set; }

    [ForeignKey("Attendee")]
    public Guid? AttendeeId { get; set; }
    public Attendee Attendee { get; set; }

    [ForeignKey("Payment")]
    public Guid? PaymentId { get; set; }
    public Payment Payment { get; set; }

    [Required]
    public string QRCode { get; set; }

    [Required]
    public string Status { get; set; }
}
