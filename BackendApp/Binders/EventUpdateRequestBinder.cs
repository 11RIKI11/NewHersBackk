using Core.Model.DTO.Event;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Infrastructure.Binders;

public class EventUpdateRequestBinder : IModelBinder
{
    public async Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var eventRequest = new EventUpdateRequest();
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

        if (bool.TryParse(form["IsActive"], out bool isActive))
            eventRequest.IsActive = isActive;

        var imageFiles = form.Files.Where(f => f.Name.StartsWith("ImageFiles")).ToList();
        var imageIds = form["ImageIds"];
        var orderRanks = form["LocalOrderRanks"];

        for (int i = 0; i < Math.Max(imageFiles.Count, imageIds.Count); i++)
        {
            var imageRequest = new EventImageUpdateRequest();

            var id = imageIds[i];
            if (Guid.TryParse(id, out Guid imageId))
            {
                imageRequest.Id = imageId;
            }

            var image = imageFiles[i];
            if (image != null)
            {
                imageRequest.Image = image;
            }

            var orderRank = orderRanks[i];
            if (short.TryParse(orderRank, out short rank))
            {
                imageRequest.LocalOrderRank = rank;
            }

            if (imageRequest.Id != Guid.Empty || imageRequest.Image != null)
            {
                eventRequest.Images.Add(imageRequest);
            }
        }

        bindingContext.Result = ModelBindingResult.Success(eventRequest);
    }
}