using System.ComponentModel.DataAnnotations;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringLengthIfNotNullAttribute : ValidationAttribute
    {
        private readonly int _maxLength;

        public StringLengthIfNotNullAttribute(int maxLength)
            : base($"String cannot exceed {maxLength} characters")
        {
            _maxLength = maxLength;
        }

        public override bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrEmpty(value as string))
                return true;

            return (value as string)!.Length <= _maxLength;
        }
    }
}
