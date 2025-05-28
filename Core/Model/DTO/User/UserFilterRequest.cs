using Core.Enums;
using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.User;

//[DateValidation("BirthDateFrom", "BirthDateTo")]
[DateValidation("CreatedAtFrom", "CreatedAtTo")]
public class UserFilterRequest
{
    public List<Guid> UserIds { get; set; } = new List<Guid>();
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLengthIfNotNull(100)]
    public string? Email { get; set; } = null;
    
    [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Phone number must be in a valid format.")]
    [StringLengthIfNotNull(15)]
    public string? Phone { get; set; } = null;
    
    [StringLengthIfNotNull(100)]
    public string? FullName { get; set; } = null;
    
    public List<UserRoles> Roles { get; set; } = new List<UserRoles>(); //Поменял на Enum

    [DataType(DataType.Date)]
    [MaxAge(100, ErrorMessage = "Возраст не должен превышать 100 лет")]
    [MinAge(18, ErrorMessage = "Возраст не должен быть меньше 18 лет")]
    public DateTime? BirthDateFrom { get; set; } = null;

    [DataType(DataType.Date)]
    [MaxAge(100, ErrorMessage = "Возраст не должен превышать 100 лет")]
    [MinAge(18, ErrorMessage = "Возраст не должен быть меньше 18 лет")]
    public DateTime? BirthDateTo { get; set; } = null;
    
    [DateValidation]
    public DateTime? CreatedAtFrom { get; set; } = null;
    
    [DateValidation]
    public DateTime? CreatedAtTo { get; set; } = DateTime.UtcNow;
}
