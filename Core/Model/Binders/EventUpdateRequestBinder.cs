using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Binders;

public class EventUpdateRequestBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var eventRequest = new EventUpdateRequest();
        var form = bindingContext.HttpContext.Request.Form;

        eventRequest.Title = form["title"];
        eventRequest.Description = form["description"];
        eventRequest.Location = form["location"];

        if (DateTime.TryParse(form["startDate"], out DateTime startDate))
            eventRequest.StartDate = startDate;

        if (DateTime.TryParse(form["endDate"], out DateTime endDate))
            eventRequest.EndDate = endDate;

        if (int.TryParse(form["ticketCount"], out int ticketCount))
            eventRequest.TicketCount = ticketCount;

        if (decimal.TryParse(form["price"], out decimal price))
            eventRequest.Price = price;

        if (bool.TryParse(form["isActive"], out bool isActive))
            eventRequest.IsActive = isActive;

        eventRequest.Tag = form["tag"];

        // Обработка изображений в формате images[0].id, images[0].image, images[0].localOrderRank
        var files = form.Files;
        int index = 0;

        while (true)
        {
            var idKey = $"images[{index}].id";
            var imageKey = $"images[{index}].image";
            var rankKey = $"images[{index}].localOrderRank";

            if (!form.ContainsKey(idKey) && !form.ContainsKey(rankKey) && !files.Any(f => f.Name == imageKey))
                break;

            var imageRequest = new EventImageUpdateRequest();

            if (form.ContainsKey(idKey) && Guid.TryParse(form[idKey], out Guid imageId))
                imageRequest.Id = imageId;
            else
                imageRequest.Id = Guid.Empty;

            var file = files.FirstOrDefault(f => f.Name == imageKey);
            if (file != null)
                imageRequest.Image = file;

            if (form.ContainsKey(rankKey) && short.TryParse(form[rankKey], out short rank))
                imageRequest.LocalOrderRank = rank;
            else
                imageRequest.LocalOrderRank = -1;

            if ((imageRequest.Image != null || imageRequest.Id != Guid.Empty )&& imageRequest.LocalOrderRank >= 0)
                eventRequest.Images.Add(imageRequest);

            index++;
        }

        bindingContext.Result = ModelBindingResult.Success(eventRequest);
    }
}