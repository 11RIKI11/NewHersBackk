using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidateAttribute.Date
{
    public class MaxAgeAttribute : ValidationAttribute
    {
        private readonly int _maxAge;

        public MaxAgeAttribute(int maxAge)
        {
            _maxAge = maxAge;
            ErrorMessage = $"Age must not exceed {_maxAge} years.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            if (value is not DateTime birthDate)
                return new ValidationResult("Invalid date format.");

            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;

            return age > _maxAge
                ? new ValidationResult(ErrorMessage)
                : ValidationResult.Success;
        }
    }
}
