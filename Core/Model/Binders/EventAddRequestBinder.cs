using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Binders;

public class EventAddRequestBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var eventRequest = new EventAddRequest();
        var form = bindingContext.HttpContext.Request.Form;

        eventRequest.Title = form["title"];
        eventRequest.Description = form["description"];
        eventRequest.Location = form["location"];

        if (DateTime.TryParse(form["startDate"], out DateTime startDate))
            eventRequest.StartDate = startDate;

        if (DateTime.TryParse(form["endDate"], out DateTime endDate))
            eventRequest.EndDate = endDate;

        if (int.TryParse(form["ticketCount"], out int ticketCount))
            eventRequest.TicketsCount = ticketCount;

        if (decimal.TryParse(form["price"], out decimal price))
            eventRequest.Price = price;

        eventRequest.Tag = form["tag"];

        // Обработка изображений в формате images[0].id, images[0].image, images[0].localOrderRank
        var files = form.Files;
        int index = 0;

        while (true)
        {
            var imageKey = $"images[{index}].image";
            var rankKey = $"images[{index}].localOrderRank";

            if (!form.ContainsKey(rankKey) && !files.Any(f => f.Name == imageKey))
                break;

            var imageRequest = new EventImageAddRequest();

            var file = files.FirstOrDefault(f => f.Name == imageKey);
            if (file != null)
                imageRequest.Image = file;

            if (form.ContainsKey(rankKey) && short.TryParse(form[rankKey], out short rank))
                imageRequest.LocalOrderRank = rank;
            else
                imageRequest.LocalOrderRank = -1;

            if ((imageRequest.Image != null) && imageRequest.LocalOrderRank >= 0)
                eventRequest.Images.Add(imageRequest);

            index++;
        }

        bindingContext.Result = ModelBindingResult.Success(eventRequest);
    }
}