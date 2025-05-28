using System.ComponentModel.DataAnnotations;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class EntityPairValidationAttribute : ValidationAttribute
    {
        private readonly string _entityIdPropertyName;
        private readonly string _entityTargetPropertyName;
        private readonly string _imageTypePropertyName;

        public EntityPairValidationAttribute(string entityIdPropertyName, string entityTargetPropertyName, string imageTypePropertyName)
            : base("Entity pair validation failed")
        {
            _entityIdPropertyName = entityIdPropertyName;
            _entityTargetPropertyName = entityTargetPropertyName;
            _imageTypePropertyName = imageTypePropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var entityIdProperty = validationContext.ObjectType.GetProperty(_entityIdPropertyName);
            var entityTargetProperty = validationContext.ObjectType.GetProperty(_entityTargetPropertyName);
            var imageTypeProperty = validationContext.ObjectType.GetProperty(_imageTypePropertyName);

            if (entityIdProperty != null && entityTargetProperty != null && imageTypeProperty != null)
            {
                var entityId = entityIdProperty.GetValue(validationContext.ObjectInstance) as string;
                var entityTarget = entityTargetProperty.GetValue(validationContext.ObjectInstance) as string;
                var imageType = imageTypeProperty.GetValue(validationContext.ObjectInstance) as string;

                bool isEntityIdFilled = !string.IsNullOrEmpty(entityId);
                bool isEntityTargetFilled = !string.IsNullOrWhiteSpace(entityTarget);

                // Проверка: EntityId и EntityTarget должны быть либо оба заполнены, либо оба пусты
                if (isEntityIdFilled != isEntityTargetFilled)
                {
                    return new ValidationResult(
                        "EntityId and EntityTarget must either both be filled or both be empty.",
                        new[] { _entityIdPropertyName, _entityTargetPropertyName });
                }

                // Проверка: Если EntityId и EntityTarget пусты, ImageType должен быть заполнен
                if (!isEntityIdFilled && !isEntityTargetFilled && string.IsNullOrWhiteSpace(imageType))
                {
                    return new ValidationResult(
                        "ImageType must be filled if EntityId and EntityTarget are empty.",
                        new[] { _imageTypePropertyName });
                }
            }

            return ValidationResult.Success;
        }
    }
}
