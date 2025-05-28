using Core.Model.DTO.Event;
using Core.Model.DTO.Image;
using Core.Model.Entities;

namespace Core.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int page, int pageSize)
        {
            if (page < 1)
                page = 1;
            if (pageSize < 1)
                pageSize = 20;

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static IQueryable<EventResponse> IncludeEventImages(this IQueryable<Event> events, IQueryable<Image> images)
        {
            return events.Select(e => new EventResponse
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                Location = e.Location,
                StartTime = e.StartTime,
                EndTime = e.EndTime,
                Price = e.Price,
                IsActive = e.IsActive,
                Images = images.Where(i => i.EntityId == e.Id.ToString())
                    .Select(i => new ImageResponse
                    {
                        Id = i.Id,
                        ImageUrl = i.ImageUrl,
                        ImageType = i.ImageType,
                        LocalOrderRank = i.LocalOrderRank
                    }).ToList()
            });
        }
    }
}
