using Core.Enums;
using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;
using Core.ValidateAttribute.Date;

namespace Core.Model.DTO.Attendee;

public class AttendeeUpdateRequest
{
    [Required]
    [FullNameValidation]
    public string FullName { get; set; } = string.Empty;
    [Required]
    //Сделай валидацию даты чтобы максимум было 100 лет
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [MaxAge(100, ErrorMessage = "Возраст не должен превышать 100 лет")]
    public DateTime BirthDate { get; set; }

    [Required]
    [EnumDataType(typeof(DocumentType), ErrorMessage = "Тип документа не соответствует типу документа")]
    public DocumentType DocumentType { get; set; } = DocumentType.Passport;

    [Required]
    [StringLength(20, ErrorMessage = "Номер документа не должен превышать 20 символов")]
    public string DocumentNumber { get; set; } = string.Empty;
}

