using AutoMapper;
using Core.Enums;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.Event;
using Core.Model.DTO.Image;
using Core.Model.DTO.Ticket;
using Core.Model.Entities;
using Core.Results;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Service;

public class EventService
{
    private readonly ApplicationDbContext _context;
    private readonly ImageService _imageService;
    private readonly TicketService _ticketService;
    private readonly IMapper _mapper;

    public EventService(ApplicationDbContext context, ImageService imageService, TicketService ticketService, IMapper mapper)
    {
        _context = context;
        _imageService = imageService;
        _ticketService = ticketService;
        _mapper = mapper;
    }

    // Получить событие по Id
    public async Task<ServiceResult<EventResponse>> GetEventByIdAsync(Guid id)
    {
        var eventResponse = await _context.Events
            .IncludeEventImages(_context.Images)
            .FirstOrDefaultAsync();

        if (eventResponse == null)
            return ServiceResult<EventResponse>.Failure("Событие с таким Id не найдено", 404);

        return ServiceResult<EventResponse>.Success(eventResponse);
    }

    // Получить список событий с пагинацией
    public async Task<ServiceResult<SearchResultResponse<EventResponse>>> GetEventsAsync(EventSearchRequest request)
    {
        var query = _context.Events.AsQueryable();

        // Поиск
        if (request.Filter.EventIds.Count() > 0)
        {
            query = query.Where(e => request.Filter.EventIds.Contains(e.Id));
        }

        if (request.Filter.Title.Count > 0)
        {
            query = query.Where(e => request.Filter.Title.Any(title =>
        EF.Functions.ILike(e.Title, title + "%") || EF.Functions.ILike(e.Title, "%" + title)
    ));
        }

        if (request.Filter.Location.Count > 0)
        {
            query = query.Where(e => request.Filter.Location.Any(location => EF.Functions.ILike(e.Location, location + "%") ||
                                     EF.Functions.ILike(e.Location, " %" + location)));
        }

        if (request.Filter.Tag.Count > 0)
        {
            query = query.Where(e => request.Filter.Tag.Any(tag => EF.Functions.ILike(e.Tag, tag + "%") ||
                                     EF.Functions.ILike(e.Tag, " %" + tag)));
        }

        if (!string.IsNullOrEmpty(request.Filter.Description))
        {
            query = query.Where(e => EF.Functions.ILike(e.Description, request.Filter.Description + "%") ||
                                     EF.Functions.ILike(e.Description, " %" + request.Filter.Description));
        }

        if (request.Filter.IsActive != null)
        {
            query = query.Where(e => e.IsActive == request.Filter.IsActive);
        }

        if (request.Filter.MinPrice != null)
        {
            query = query.Where(e => e.Price >= request.Filter.MinPrice);
        }

        if (request.Filter.MaxPrice != null)
        {
            query = query.Where(e => e.Price <= request.Filter.MaxPrice);
        }

        if(request.Filter.DateTo != null)
            query = query.Where(e => e.StartTime <= request.Filter.DateTo);


        if (request.Filter.DateFrom != null)
            query = query.Where(e => e.StartTime >= request.Filter.DateFrom);

        query = SortingHelper.ApplySorting(query, request.Sort);

        var totalCount = await query.CountAsync();

        // Пагинация
        var eventResponses = await query
            .Paginate(request.Pagination.Page, request.Pagination.PageSize)
            .IncludeEventImages(_context.Images)
            .ToListAsync();

        var resultResponse = new SearchResultResponse<EventResponse>
        {
            Items = _mapper.Map<List<EventResponse>>(eventResponses),
            TotalCount = totalCount
        };

        return ServiceResult<SearchResultResponse<EventResponse>>.Success(resultResponse);
    }

    // Создать новое событие
    public async Task<ServiceResult<EventResponse>> CreateEventAsync(EventAddRequest request)
    {
        var newEvent = _mapper.Map<Event>(request);

        await _context.Events.AddAsync(newEvent);
        await _context.SaveChangesAsync();

        var eventResponse = _mapper.Map<EventResponse>(newEvent);

        var ticketAddRequests = new List<TicketAddRequest>();

        for (int i = 0; i < request.TicketCount; i++)
        {
            ticketAddRequests.Add(
                new TicketAddRequest
                {
                    EventId = newEvent.Id
                });
        }

        var ticketResponse = await _ticketService.CreateTicketsAsync(ticketAddRequests);

        if (request.Image.Count > 0)
        {
            var imageAdd = request.Image.Zip(request.LocalOrderRank, (image, rank) => new ImageAddRequest()
            {
                Image = image,
                LocalOrderRank = rank
            }
            ).ToList();
            var imageResponse = await AddEventImagesAsync(newEvent.Id, imageAdd);
            if (!imageResponse.IsSuccess)
                return ServiceResult<EventResponse>.Failure(imageResponse.Error.ErrorMessage, imageResponse.Error.StatusCode);
            eventResponse.Images = imageResponse.Data.Items;
        }

        return ServiceResult<EventResponse>.Success(eventResponse);
    }

    // Обновить данные события
    public async Task<ServiceResult<bool>> UpdateEventAsync(Guid id, EventUpdateRequest request)
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

        if (eventEntity == null)
            return ServiceResult<bool>.Failure("Событие с таким Id не найдено", 404);
        if (request.Title != null)
            eventEntity.Title = request.Title;
        if (request.Description != null)
            eventEntity.Description = request.Description;
        if (request.Location != null)
            eventEntity.Location = request.Location;
        eventEntity.StartTime = request.StartDate;
        eventEntity.EndTime = request.EndDate;
        eventEntity.Price = request.Price;
        eventEntity.IsActive = request.IsActive;
        eventEntity.Tag = request.Tag;
        //eventEntity.TicketsCount = request.TicketCount;

        if (eventEntity.TicketsCount > request.TicketCount)
        {
            var ticketsToRemove = await _context.Tickets
                .Where(t => t.EventId == eventEntity.Id && ((t.Payment == null ? true : t.Payment.Status.ToString().ToLower() == TicketStatus.Available.ToString().ToLower())))
                .Take(request.TicketCount)
                .ToListAsync();
            if (ticketsToRemove.Count > 0)
            {
                _context.Tickets.RemoveRange(ticketsToRemove);
            }
        }
        else if (eventEntity.TicketsCount < request.TicketCount)
        {
            var ticketAddRequests = new List<TicketAddRequest>();
            for (int i = 0; i < request.TicketCount - eventEntity.TicketsCount; i++)
            {
                ticketAddRequests.Add(new TicketAddRequest { EventId = eventEntity.Id });
            }
            await _ticketService.CreateTicketsAsync(ticketAddRequests);
        }
        eventEntity.TicketsCount = request.TicketCount;

        // Обновить изображения события
        if (request.Images.Count > 0)
        {
            await UpdateEventImagesAsync(request.Images);
        }

        _context.Events.Update(eventEntity);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> UpdateEventImagesAsync(List<EventImageUpdateRequest> requests)
    {
        foreach (var request in requests)
        {
            var result = await _imageService.UpdateImageAsync(request.Id, request.Image);
            if(result.IsSuccess)
            {
                requests.Remove(request);
            }
        }
        
        if (requests.Count > 0)
        {
            var images = new List<ImageAddRequest>();
            foreach (var request in requests)
            {
                var image = new ImageAddRequest
                {
                    EntityTarget = "event",
                    EntityId = request.Image.EntityId,
                    Image = request.Image.Image
                };
                images.Add(image);
            }
            var result = await _imageService.AddUploadedImagesAsync(images);
        }
        return ServiceResult<bool>.Success();
    }

    // Удалить событие
    //Поправила
    public async Task<ServiceResult<bool>> DeleteEventAsync(Guid id)
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);

        if (eventEntity == null)
            return ServiceResult<bool>.Failure("Событие с таким Id не найдено", 404);

        // Удалить связанные изображения
        var imageIds = await _context.Images
            .Where(ei => ei.EntityId == id.ToString())//шото хуета ну да ладно))
            .Select(ei => ei.Id)
            .ToListAsync();

        await _imageService.RemoveImages(imageIds);

        _context.Events.Remove(eventEntity);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success(true);
    }

    // Добавить изображения к событию
    //Поправит
    public async Task<ServiceResult<SearchResultResponse<ImageResponse>>> AddEventImagesAsync(Guid eventId, List<ImageAddRequest> request)//тут сделала как лист ибо добавить Images
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);

        if (eventEntity == null)
            return ServiceResult<SearchResultResponse<ImageResponse>>.Failure("Событие с таким Id не найдено", 404);

        foreach (var imageRequest in request)
        {
            imageRequest.EntityTarget = "event";
            imageRequest.EntityId = eventId.ToString();
        }//можешь сделать метод который добавит весь лист, мне было лень)) в сервисе картинок`

        var result = await _imageService.AddUploadedImagesAsync(request);
        if (!result.IsSuccess)
            return ServiceResult<SearchResultResponse<ImageResponse>>.Failure(result.Error.ErrorMessage, result.Error.StatusCode);

        var mappedImages = _mapper.Map<List<ImageResponse>>(result.Data);

        var response = new SearchResultResponse<ImageResponse>
        {
            Items = mappedImages,
            TotalCount = mappedImages.Count
        };

        return ServiceResult<SearchResultResponse<ImageResponse>>.Success(response);
    }

    // Удалить изображения события
    //Поправила
    public async Task<ServiceResult<bool>> RemoveEventImagesAsync(List<Guid> imageIds)
    {
        await _imageService.RemoveImages(imageIds);
        return ServiceResult<bool>.Success();
    }
}
