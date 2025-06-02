using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Binders;
public class EventUpdateRequestBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        if (context.Metadata.ModelType == typeof(EventUpdateRequest))
            return new EventUpdateRequestBinder();

        throw new InvalidOperationException($"No binder found for model type {context.Metadata.ModelType.FullName}");
    }
}