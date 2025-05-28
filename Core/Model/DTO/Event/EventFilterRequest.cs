using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;
using Core.ValidateAttribute.Date;

namespace Core.Model.DTO.Event;

[DateValidation("DateFrom", "DateTo")]
[PriceRange("MinPrice", "MaxPrice")]
public class EventFilterRequest
{
    public List<Guid> EventIds { get; set; } = new List<Guid>();
    
    public DateTime? DateFrom { get; set; } = null;

    public DateTime? DateTo { get; set; } = null;

    [Range(0.01, double.MaxValue, ErrorMessage = "MinPrice must be a positive number.")]
    public decimal? MinPrice { get; set; } = null;
    
    [Range(0.01, double.MaxValue, ErrorMessage = "MaxPrice must be a positive number.")]
    public decimal? MaxPrice { get; set; } = null;
    
    [StringLengthIfNotNull(100)]
    public List<string> Title { get; set; } = new List<string>();
    
    [StringLengthIfNotNull(200)]
    public List<string> Location { get; set; } = new List<string>();

    public List<string> Tag { get; set; } = new List<string>(); // e.g., "excursion", "event"

    public bool? IsActive { get; set; } = null;
    public string? Description { get; set; } = null;
}
