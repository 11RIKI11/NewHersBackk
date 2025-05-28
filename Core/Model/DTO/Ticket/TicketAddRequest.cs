using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Ticket;
public class TicketAddRequest
{
    [Required(ErrorMessage = "Event ID is required.")]
    public Guid EventId { get; set; }
}
