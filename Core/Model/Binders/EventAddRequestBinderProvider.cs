using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Model.Binders;

public class EventAddRequestBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        // Возвращаем биндер ТОЛЬКО для EventAddRequest
        if (context.Metadata.ModelType == typeof(EventAddRequest))
            return new EventAddRequestBinder();

        return null; // Для всех остальных типов возвращаем null
    }
}