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
    
    [StringLengthIfNotNull(20)]
    //[RegularExpression(@"^(Admin|User|Manager)$", ErrorMessage = "Role must be either Admin, User, or Manager.")]
    //[EnumDataType(typeof(UserRoles))]
    public List<UserRoles> Roles { get; set; } = new List<UserRoles>(); //Поменял на Enum
    
    //[DateValidation]
    //public DateTime? BirthDateFrom { get; set; } = null;
    
    //[DateValidation]
    //public DateTime BirthDateTo { get; set; } = DateTime.UtcNow;
    
    [DateValidation]
    public DateTime? CreatedAtFrom { get; set; } = null;
    
    [DateValidation]
    public DateTime? CreatedAtTo { get; set; } = DateTime.UtcNow;
}
