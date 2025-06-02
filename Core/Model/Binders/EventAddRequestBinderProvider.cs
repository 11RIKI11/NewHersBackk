using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Model.Binders;

public class EventAddRequestBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        if (context.Metadata.ModelType == typeof(EventAddRequest))
            return new EventAddRequestBinder();

       throw new InvalidOperationException($"No binder found for model type {context.Metadata.ModelType.Name}.");
    }
}