using Core.Enums;
using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Payment;

public class PaymentUpdateRequest : IValidatableObject
{
    public PaymentStatus? Status { get; set; } = null;
    
    [DateValidation(AllowFutureDate = true)]
    public DateTime? PaidAt { get; set; } = null;
    
    [StringLengthIfNotNull(255)]
    public string? QrUrl { get; set; } = null;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Проверка, что при установке статуса "Оплачено" указана дата оплаты
        if (Status == PaymentStatus.Pending && !PaidAt.HasValue)
        {
            yield return new ValidationResult(
                "When status is set to Paid, PaidAt date must be provided.",
                new[] { nameof(PaidAt) });
        }

        // Проверка, что URL QR-кода указан для статуса "Ожидание оплаты"
        if (Status == PaymentStatus.WaitingForCapture && string.IsNullOrWhiteSpace(QrUrl))
        {
            yield return new ValidationResult(
                "When status is set to WaitingForPayment, QR URL must be provided.",
                new[] { nameof(QrUrl) });
        }
    }
}
