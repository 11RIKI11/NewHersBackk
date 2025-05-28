using Core.Enums;

namespace Core.Model.DTO.Ticket;

public class TicketShortResponse
{
    public Guid Id { get; set; }
    public TicketStatus Status { get; set; } = TicketStatus.Available;
}

