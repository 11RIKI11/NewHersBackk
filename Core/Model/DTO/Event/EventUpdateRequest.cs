using Core.Model.DTO.Image;
using Core.Model.DTO.Ticket;
using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;
using Core.ValidateAttribute.Date;

namespace Core.Model.DTO.Event;

[DateValidation("StartDate", "EndDate", AllowFutureDate = true, RequireFuture = true, RequireMinHourFromNow = true)]
[ImageOrderValidation("Images")]
public class EventUpdateRequest
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title must not exceed 100 characters.")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(500, ErrorMessage = "Description must not exceed 500 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required.")]
    [StringLength(200, ErrorMessage = "Location must not exceed 200 characters.")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End date is required.")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Ticket count is required.")]
    [Range(6, int.MaxValue, ErrorMessage = "Ticket count must be greater than 5.")]
    public int TicketCount { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
    public decimal Price { get; set; }

    [Required]
    public string Tag { get; set; } = string.Empty; // e.g., "excursion", "event"

    [Required]
    public bool IsActive { get; set; }

    public List<EventImageUpdateRequest> Images { get; set; } = new List<EventImageUpdateRequest>();
}
