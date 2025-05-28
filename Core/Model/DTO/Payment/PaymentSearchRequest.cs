using Core.Enums;
using Core.Model.DTO.Payment;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Attendee;

public class PaymentSearchRequest
{
    public PaymentFilterRequest Filter { get; set; } = new PaymentFilterRequest();
    public List<SortRequest> Sort { get; set; } = new List<SortRequest>();
    public PaginationRequest Pagination { get; set; } = new PaginationRequest();
}

