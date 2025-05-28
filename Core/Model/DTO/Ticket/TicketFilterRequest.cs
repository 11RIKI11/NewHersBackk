using Core.Enums;
using Core.ValidateAttribute;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Ticket;

public class TicketFilterRequest
{
    public List<Guid> TicketIds { get; set; } = new List<Guid>();

    public List<Guid> EventIds { get; set; } = new List<Guid>();

    public List<Guid> BuyerIds { get; set; } = new List<Guid>();
    [StringLengthIfNotNull(100)]
    public string? BuyerName { get; set; } = null;
    
    public List<Guid> AttendeeIds { get; set; } = new List<Guid>();
    [StringLengthIfNotNull(100)]
    public string? AttendeeName { get; set; } = null;
    public List<Guid> PaymentIds { get; set; } = new List<Guid>();
}
