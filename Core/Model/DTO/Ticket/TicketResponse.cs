using Core.Enums;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Payment;
using Core.Model.DTO.User;

namespace Core.Model.DTO.Ticket;

public class TicketResponse
{
    public Guid Id { get; set; }
    public Guid EventId { get; set; }
    public string QRCode { get; set; } = string.Empty;
    public AttendeeResponse? Attendee { get; set; } = null;
    public PaymentResponse? Payment { get; set; } = null;
}
