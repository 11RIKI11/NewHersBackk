namespace Core.Enums;

public enum PaymentStatus
{
    Pending,
    WaitingForCapture,
    Succeeded,
    Canceled,
    Failed
}