using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Payment;

public class PaymentAddRequest : IValidatableObject
{
    [Required(ErrorMessage = "Buyer ID is required.")]
    public Guid BuyerId { get; set; }
    
    [Required(ErrorMessage = "Amount is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "Attendee IDs are required.")]
    public List<Guid> TicketIds { get; set; } = new List<Guid>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Проверка, что список билетов не пустой
        if (TicketIds == null || !TicketIds.Any())
        {
            yield return new ValidationResult(
                "At least one ticket is required.",
                new[] { nameof(TicketIds) });
        }

        // Проверка наличия дубликатов ID билетов
        if (TicketIds != null && TicketIds.Count != TicketIds.Distinct().Count())
        {
            yield return new ValidationResult(
                "Duplicate ticket IDs are not allowed.",
                new[] { nameof(TicketIds) });
        }
    }
}
