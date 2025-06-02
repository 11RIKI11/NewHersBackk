using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ImageOrderValidationAttribute : ValidationAttribute
    {
        private readonly string _imagesPropertyName;

        public ImageOrderValidationAttribute(string imagesPropertyName)
            : base("Images validation failed")
        {
            _imagesPropertyName = imagesPropertyName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var imagesProperty = validationContext.ObjectType.GetProperty(_imagesPropertyName);

            if (imagesProperty != null)
            {
                var images = imagesProperty.GetValue(validationContext.ObjectInstance) as System.Collections.IEnumerable;

                /*if (images == null)
                {
                    return new ValidationResult(
                        "At least one image is required.",
                        new[] { _imagesPropertyName });
                }*/

                // Проверяем есть ли элементы в коллекции
                bool hasElements = false;
                foreach (var _ in images)
                {
                    hasElements = true;
                    break;
                }

                /*if (!hasElements)
                {
                    return new ValidationResult(
                        "At least one image is required.",
                        new[] { _imagesPropertyName });
                }*/

                // Получаем доступ к свойству LocalOrderRank для каждого изображения
                var localOrderRanks = new List<short>();

                foreach (var img in images)
                {
                    var localOrderRankProperty = img.GetType().GetProperty("LocalOrderRank");
                    if (localOrderRankProperty != null)
                    {
                        localOrderRanks.Add((short)localOrderRankProperty.GetValue(img)!);
                    }
                }

                // Проверка последовательности LocalOrderRank от 0 до N-1
                localOrderRanks = localOrderRanks.OrderBy(rank => rank).ToList();
                for (int i = 0; i < localOrderRanks.Count; i++)
                {
                    if (localOrderRanks[i] != i)
                    {
                        return new ValidationResult(
                            "Images LocalOrderRank must be sequential starting from 0 without gaps.",
                            new[] { _imagesPropertyName });
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
