using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.ValidateAttribute
{
    public class FullNameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var fullName = value as string;
            if (string.IsNullOrWhiteSpace(fullName))
                return new ValidationResult("Full name is required.");

            var words = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length < 2)
                return new ValidationResult("Full name must contain at least two words.");

            // Regex для проверки слова: с заглавной буквы, минимум 2 символа
            var ruRegex = new Regex(@"^[А-ЯЁ][а-яё]{1,}$");
            var enRegex = new Regex(@"^[A-Z][a-z]{1,}$");

            bool allRussian = words.All(w => ruRegex.IsMatch(w));
            bool allEnglish = words.All(w => enRegex.IsMatch(w));

            if (!allRussian && !allEnglish)
                return new ValidationResult("Full name must be entirely in Russian or English.");

            return ValidationResult.Success;
        }
    }
}
