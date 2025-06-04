using Core.Enums;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Payment;
using Core.Model.DTO.User;
using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Ticket;

public class TicketUpdateRequest
{
    public Guid? AttendeeId { get; set; } = null;

    public string QrCode { get; set; } = string.Empty;
    [Required]
    public Guid UserId { get; set; }
}
