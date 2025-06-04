using Core.Binders;
using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Event;

[ModelBinder(BinderType = typeof(EventUpdateRequestBinder))]
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

    [JsonIgnore] // Игнорируем коллекцию Images при сериализации
    public List<EventImageUpdateRequest> Images { get; set; } = new();
}
