using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Model.Binders;
public class EventUpdateRequestBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
            throw new ArgumentNullException(nameof(context));

        if (context.Metadata.ModelType == typeof(EventUpdateRequest))
            return new EventUpdateRequestBinder();

        return null;
    }
}