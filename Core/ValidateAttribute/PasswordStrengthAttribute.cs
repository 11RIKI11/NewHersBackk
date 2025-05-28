using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class PasswordStrengthAttribute : ValidationAttribute
    {
        public PasswordStrengthAttribute()
            : base("Password must be 8-100 characters, include uppercase and lowercase letters, digits, and special characters (!@#$%^&*).")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            var password = value as string;
            if (string.IsNullOrWhiteSpace(password))
                return false;

            var pattern = @"^(?=.*[a-zа-яё])(?=.*[A-ZА-ЯЁ])(?=.*\d)(?=.*[!@#$%^&*]).{8,100}$";
            return Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }
    }
}
