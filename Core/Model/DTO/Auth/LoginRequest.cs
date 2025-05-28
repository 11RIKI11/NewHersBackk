using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Model.DTO.Auth;

public class LoginRequest : IValidatableObject
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var pattern = @"^(?=.*[a-zа-яё])(?=.*[A-ZА-ЯЁ])(?=.*\d)(?=.*[!@#$%^&*]).{8,100}$";
        if (!Regex.IsMatch(Password, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return new ValidationResult("Password must meet the required complexity.", new[] { nameof(Password) });
        }
    }
}