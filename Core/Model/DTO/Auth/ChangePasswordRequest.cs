using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Auth;

public class ChangePasswordRequest
{
    [Required(ErrorMessage = "Old password is required.")]
    [PasswordStrength]
    public string OldPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "New password is required.")]
    [PasswordStrength]
    public string NewPassword { get; set; } = string.Empty;
}
