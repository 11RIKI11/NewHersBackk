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

    //[EnumDataType(typeof(TicketStatus))]
    public List<TicketStatus> Status { get; set; } = new List<TicketStatus>();
    
    //[StringLengthIfNotNull(15)]
    //[RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Contact phone must be a valid phone number.")]
    //public string? ContactPhone { get; set; } = null;
    public List<Guid> PaymentIds { get; set; } = new List<Guid>();
}
