using System.ComponentModel.DataAnnotations;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PriceRangeAttribute : ValidationAttribute
    {
        private readonly string _minPricePropertyName;
        private readonly string _maxPricePropertyName;

        public PriceRangeAttribute(string minPricePropertyName, string maxPricePropertyName)
            : base($"{minPricePropertyName} cannot be greater than {maxPricePropertyName}")
        {
            _minPricePropertyName = minPricePropertyName;
            _maxPricePropertyName = maxPricePropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var minPriceProperty = validationContext.ObjectType.GetProperty(_minPricePropertyName);
            var maxPriceProperty = validationContext.ObjectType.GetProperty(_maxPricePropertyName);

            if (minPriceProperty != null && maxPriceProperty != null)
            {
                var minPrice = minPriceProperty.GetValue(validationContext.ObjectInstance) as decimal?;
                var maxPrice = maxPriceProperty.GetValue(validationContext.ObjectInstance) as decimal?;

                if (minPrice.HasValue && maxPrice.HasValue && minPrice > maxPrice)
                {
                    return new ValidationResult(
                        ErrorMessage,
                        new[] { _minPricePropertyName, _maxPricePropertyName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
