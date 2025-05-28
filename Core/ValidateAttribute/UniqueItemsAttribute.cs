using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Core.ValidateAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueItemsAttribute : ValidationAttribute
    {
        public UniqueItemsAttribute()
            : base("Collection contains duplicate items.")
        {
        }

        public override bool IsValid(object? value)
        {
            if (value == null)
                return true;

            if (value is IEnumerable items)
            {
                var hashSet = new HashSet<object>();
                
                foreach (var item in items)
                {
                    if (item != null && !hashSet.Add(item))
                    {
                        return false;
                    }
                }
            }
            
            return true;
        }
    }
}
