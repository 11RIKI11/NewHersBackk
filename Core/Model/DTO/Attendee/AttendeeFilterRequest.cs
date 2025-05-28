using Core.Enums;
using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Core.Model.DTO.Attendee;

[DateValidation("BirthDateFrom", "BirthDateTo")]
public class AttendeeFilterRequest
{
    public List<Guid> AttendeeIds { get; set; } = new List<Guid>();
    
    [StringLengthIfNotNull(100)]
    public string? FullName { get; set; } = null;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [MaxAge(100, ErrorMessage = "Возраст не должен превышать 100 лет")]
    [DateValidation]
    public DateTime? BirthDateFrom { get; set; } = null;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [MaxAge(100, ErrorMessage = "Возраст не должен превышать 100 лет")]
    [DateValidation]
    public DateTime? BirthDateTo { get; set; } = null;

    //[EnumDataType(typeof(DocumentType))]
    public List<DocumentType> DocType { get; set; } = new List<DocumentType>();
    
    [StringLengthIfNotNull(20)]
    public string? DocNumber { get; set; } = null;
}
