using Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Attendee;

public class AttendeeSearchRequest
{
    public AttendeeFilterRequest Filter { get; set; } = new AttendeeFilterRequest();
    public List<SortRequest> Sort { get; set; } = new List<SortRequest>();
    public PaginationRequest Pagination { get; set; } = new PaginationRequest();
}

