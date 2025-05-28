using Core.Enums;

namespace Core.Model.DTO.Attendee;

public class AttendeeResponse
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public DocumentType DocumentType { get; set; }
    public string DocumentNumber { get; set; }
    public DateTime CreatedAt { get; set; }
}

