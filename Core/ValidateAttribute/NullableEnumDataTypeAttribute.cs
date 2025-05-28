using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NullableEnumDataTypeAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public NullableEnumDataTypeAttribute(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("Type must be an enum");

            _enumType = enumType;
            ErrorMessage = "Invalid enum value.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;

            if (!Enum.IsDefined(_enumType, value))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;
        }
    }
}
