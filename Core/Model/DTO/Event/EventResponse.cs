using Core.Model.DTO.Image;
using Core.Model.DTO.Ticket;

namespace Core.Model.DTO.Event;

public class EventResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string Tag { get; set; } = string.Empty; // e.g., "excursion", "event"
    public List<ImageResponse> Images { get; set; } = new List<ImageResponse>();
}
