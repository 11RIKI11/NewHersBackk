using System.ComponentModel.DataAnnotations;

namespace Core.ValidateAttribute.Date
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public class DateValidationAttribute : ValidationAttribute
    {
        // Параметры для проверки диапазона дат
        private readonly string? _fromPropertyName;
        private readonly string? _toPropertyName;
        
        // Флаги для разрешения дат
        public bool AllowFutureDate { get; set; }
        public bool RequireFuture { get; set; }
        public bool RequireMinHourFromNow { get; set; }

        #region Конструкторы

        // Конструктор для проверки, что дата не в будущем (на уровне свойства)
        public DateValidationAttribute() 
            : base("Date cannot be in the future")
        {
        }

        // Конструктор для проверки диапазона дат (fromDate <= toDate)
        public DateValidationAttribute(string fromPropertyName, string toPropertyName)
            : base($"{fromPropertyName} cannot be greater than {toPropertyName}")
        {
            _fromPropertyName = fromPropertyName;
            _toPropertyName = toPropertyName;
        }

        #endregion

        public override bool IsValid(object? value)
        {
            // Этот метод вызывается при применении атрибута к свойству
            if (value == null)
                return true;

            if (value is DateTime dateValue)
            {
                DateTime now = DateTime.UtcNow;

                // Проверка на будущее
                if (!AllowFutureDate && dateValue.Date > now.Date)
                {
                    return false;
                }

                // Проверка на требование даты в будущем
                if (RequireFuture && dateValue.Date <= now.Date)
                {
                    return false;
                }

                // Проверка на минимальное время от текущего (1 час)
                if (RequireMinHourFromNow && dateValue <= now.AddHours(1))
                {
                    return false;
                }
                
                return true;
            }

            return false;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            // Этот метод вызывается при применении атрибута к классу или когда нужна проверка с учетом других свойств
            
            // Если атрибут применен к свойству для проверки будущей даты
            if (_fromPropertyName == null && _toPropertyName == null && validationContext.ObjectInstance != value)
            {
                return ValidationResult.Success;
            }

            // Если атрибут применен к классу для проверки диапазона дат
            if (_fromPropertyName != null && _toPropertyName != null)
            {
                var fromProperty = validationContext.ObjectType.GetProperty(_fromPropertyName);
                var toProperty = validationContext.ObjectType.GetProperty(_toPropertyName);

                if (fromProperty == null || toProperty == null)
                    return ValidationResult.Success;

                var fromValue = fromProperty.GetValue(validationContext.ObjectInstance);
                var toValue = toProperty.GetValue(validationContext.ObjectInstance);

                // Если любое из значений null, валидация пройдена
                if (fromValue == null || toValue == null)
                    return ValidationResult.Success;

                // Для DateTime
                if (fromValue is DateTime fromDateTime && toValue is DateTime toDateTime)
                {
                    DateTime now = DateTime.UtcNow;

                    // Проверка диапазона: fromDate <= toDate
                    if (fromDateTime > toDateTime)
                    {
                        return new ValidationResult(
                            ErrorMessage ?? $"{_fromPropertyName} cannot be greater than {_toPropertyName}.",
                            new[] { _fromPropertyName, _toPropertyName });
                    }

                    // Проверка, что дата не в будущем, если это требуется
                    if (!AllowFutureDate)
                    {
                        if (toDateTime.Date > now.Date)
                        {
                            return new ValidationResult(
                                $"{_toPropertyName} cannot be in the future.",
                                new[] { _toPropertyName });
                        }
                    }

                    // Проверка на требование даты в будущем
                    if (RequireFuture)
                    {
                        if (fromDateTime.Date <= now.Date)
                        {
                            return new ValidationResult(
                                $"{_fromPropertyName} must be in the future.",
                                new[] { _fromPropertyName });
                        }
                    }

                    // Проверка на минимальное время от текущего (1 час)
                    if (RequireMinHourFromNow)
                    {
                        if (fromDateTime <= now.AddHours(1))
                        {
                            return new ValidationResult(
                                $"{_fromPropertyName} must be at least one hour from now.",
                                new[] { _fromPropertyName });
                        }
                    }
                }
                else
                {
                    return new ValidationResult(
                        "Invalid date format.",
                        new[] { _fromPropertyName, _toPropertyName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
