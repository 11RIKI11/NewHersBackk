namespace Core.Model.DTO.Ticket;

public class TicketSearchRequest
{
    public TicketFilterRequest Filter { get; set; } = new TicketFilterRequest();
    public List<SortRequest> Sort { get; set; } = new List<SortRequest>();
    public PaginationRequest Pagination { get; set; } = new PaginationRequest();
}

