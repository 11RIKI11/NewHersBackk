using Core.Enums;
using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Core.Model.DTO.Payment;

[DateValidation("CreatedAtFrom", "CreatedAtTo")]
[DateValidation("PaidAtFrom", "PaidAtTo")]
public class PaymentFilterRequest
{
    public List<Guid> PaymentIds { get; set; } = new List<Guid>();
    public List<Guid> UserIds { get; set; } = new List<Guid>();
    
    [Range(0.01, double.MaxValue, ErrorMessage = "MinAmount must be greater than 0.")]
    public decimal? MinAmount { get; set; } = null;
    [Range(0.01, double.MaxValue, ErrorMessage = "MaxAmount must be greater than 0.")]
    public decimal? MaxAmount { get; set; } = null;

    //[EnumDataType(typeof(PaymentStatus))]
    public List<PaymentStatus> Status { get; set; } = new List<PaymentStatus>();
    
    public DateTime? CreatedAtFrom { get; set; } = null;
    
    [DateValidation]
    public DateTime? CreatedAtTo { get; set; } = DateTime.UtcNow;
    public DateTime? PaidAtFrom { get; set; } = null;

    [DateValidation]
    public DateTime? PaidAtTo { get; set; } = null;
}

