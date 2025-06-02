using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Binders;

public class EventAddRequestBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var eventRequest = new EventAddRequest();
        var form = bindingContext.HttpContext.Request.Form;

        eventRequest.Title = form["Title"].ToString();
        eventRequest.Description = form["Description"].ToString();
        eventRequest.Location = form["Location"].ToString();

        if (DateTime.TryParse(form["StartDate"], out DateTime startDate))
            eventRequest.StartDate = startDate;

        if (DateTime.TryParse(form["EndDate"], out DateTime endDate))
            eventRequest.EndDate = endDate;

        if (int.TryParse(form["TicketCount"], out int ticketCount))
            eventRequest.TicketCount = ticketCount;

        eventRequest.Tag = form["Tag"].ToString();

        if (decimal.TryParse(form["Price"], out decimal price))
            eventRequest.Price = price;

        // Bind images and their order ranks
        var imageFiles = form.Files.Where(f => f.Name.StartsWith("ImageFiles")).ToList();
        var orderRanks = form["LocalOrderRanks"];

        for (int i = 0; i < imageFiles.Count; i++)
        {
            var image = imageFiles[i];
            var orderRankValue = orderRanks[i]?.ToString();

            if (short.TryParse(orderRankValue, out short rank))
            {
                eventRequest.Images.Add(new EventImageAddRequest
                {
                    Image = image,
                    LocalOrderRank = rank
                });
            }
        }

        bindingContext.Result = ModelBindingResult.Success(eventRequest);
    }
}