using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Event;

public class EventSearchRequest
{
    public EventFilterRequest Filter { get; set; } = new EventFilterRequest();
    public List<SortRequest> Sort { get; set; } = new List<SortRequest>();
    public PaginationRequest Pagination { get; set; } = new PaginationRequest();
}
