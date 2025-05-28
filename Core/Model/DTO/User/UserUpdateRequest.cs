using Core.Enums;
using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Model.DTO.User;

public class UserUpdateRequest
{
    [StringLengthIfNotNull(100)]
    [FullNameValidation]
    public string? FullName { get; set; } = null;
    
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLengthIfNotNull(100)]
    public string? Email { get; set; } = null;
    
    [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Phone number must be in a valid format.")]
    [StringLengthIfNotNull(15)]
    public string? Phone { get; set; } = null;
    
    [StringLengthIfNotNull(20)]
    [RegularExpression(@"^(Admin|User|Manager)$", ErrorMessage = "Role must be either Admin, User, or Manager.")]
    public UserRoles? Role { get; set; } = null;
}
