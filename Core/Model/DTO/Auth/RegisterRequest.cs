using Core.ValidateAttribute;
using Core.ValidateAttribute.Date;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.Model.DTO.Auth;

public class RegisterRequest : IValidatableObject
{
    [Required]
    [FullNameValidation]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\+?[0-9]{10,15}$",
        ErrorMessage = "Phone number must start with +7 or 8 and contain 11 digits.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Birthdate is required")]
    [DateValidation]
    [MinAge(18, ErrorMessage = "Возраст должен быть не меньше 18 лет")]
    [MaxAge(100, ErrorMessage = "Возраст должен быть не больеш 100 лет")]
    public DateTime BirthDate { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var pattern = @"^(?=.*[a-zа-яё])(?=.*[A-ZА-ЯЁ])(?=.*\d)(?=.*[!@#$%^&*]).{8,100}$";
        if (!Regex.IsMatch(Password, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
        {
            yield return new ValidationResult("Password must meet the required complexity.", new[] { nameof(Password) });
        }
    }
}
