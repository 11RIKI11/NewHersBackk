using Core.Enums;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.User;
using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Ticket;

public class TicketUpdateRequest : IValidatableObject
{
    [Required(ErrorMessage = "Status is required.")]
    [EnumDataType(typeof(TicketStatus), ErrorMessage = "Invalid ticket status.")]
    public TicketStatus Status { get; set; }
    
    public Guid? AttendeeId { get; set; } = null;
    
    public Guid? BuyerId { get; set; } = null;

    public string QrCode { get; set; } = string.Empty;

    public Guid? PaymentId { get; set; } = Guid.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Если статус "Assigned", должен быть указан AttendeeId
        if (Status == TicketStatus.Paid && !AttendeeId.HasValue)
        {
            yield return new ValidationResult(
                "Attendee ID is required when status is set to Assigned.",
                new[] { nameof(AttendeeId) });
        }

        // Если статус "Sold" или "Reserved", должен быть указан BuyerId
        if ((Status == TicketStatus.Paid || Status == TicketStatus.Reserved) && !BuyerId.HasValue)
        {
            yield return new ValidationResult(
                "Buyer ID is required when status is set to Sold or Reserved.",
                new[] { nameof(BuyerId) });
        }
    }
}
