using Core.Enums;
using Core.Model.DTO.User;

namespace Core.Model.DTO.Payment;

public class PaymentResponse
{
    public Guid Id { get; set; }
    public UserResponse? Buyer { get; set; } = null;
    public decimal Amount { get; set; } = 0.0m;
    public PaymentStatus Status { get; set; } = PaymentStatus.WaitingForPayment;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PaidAt { get; set; } = null;
    public string QrUrl { get; set; } = string.Empty;
}

