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
            .FirstOrDefaultAsync(i => i.Id == id);

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

        // Создаем билеты
        var ticketAddRequests = Enumerable.Range(0, request.TicketsCount)
            .Select(_ => new TicketAddRequest { EventId = newEvent.Id })
            .ToList();

        await _ticketService.CreateTicketsAsync(ticketAddRequests);
        
        // Обрабатываем изображения, если они есть
        if (request.Images.Any())
        {
            // Преобразуем EventImageAddRequest в ImageAddRequest
            var imageAddRequests = request.Images
                .Where(img => img.Image != null)
                .Select(img => new ImageAddRequest
                {
                    Image = img.Image,
                    LocalOrderRank = img.LocalOrderRank,
                    EntityTarget = "event",
                    EntityId = newEvent.Id.ToString()
                }).ToList();

            if (imageAddRequests.Any())
            {
                List<ImageResponse> images = new List<ImageResponse>();
                for (int i = 0; i < imageAddRequests.Count; i++)
                {
                    var img = await _imageService.AddUploadedImageAsync(imageAddRequests[i]);
                    if (!img.IsSuccess)
                        return ServiceResult<EventResponse>.Failure(img.Error.ErrorMessage, img.Error.StatusCode);

                    images.Add(img.Data);
                }
                eventResponse.Images = images;
            }

        }

        return ServiceResult<EventResponse>.Success(eventResponse);
    }

    // Обновить данные события
    public async Task<ServiceResult<bool>> UpdateEventAsync(Guid id, EventUpdateRequest request)
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        if (eventEntity == null)
            return ServiceResult<bool>.Failure("Событие с таким Id не найдено", 404);

        // Обновляем основные поля
        eventEntity.Title = request.Title;
        eventEntity.Description = request.Description;
        eventEntity.Location = request.Location;
        eventEntity.StartTime = request.StartDate.ToUniversalTime();
        eventEntity.EndTime = request.EndDate.ToUniversalTime();
        eventEntity.Price = request.Price;
        eventEntity.IsActive = request.IsActive;
        eventEntity.Tag = request.Tag;

        // Обновляем билеты
        if (eventEntity.TicketsCount > request.TicketCount)
        {
            var ticketsToRemove = await _context.Tickets
                .Where(t => t.EventId == eventEntity.Id && t.Payment == null )
                .Take(eventEntity.TicketsCount - request.TicketCount)
                .ToListAsync();

            if (ticketsToRemove.Any())
            {
                _context.Tickets.RemoveRange(ticketsToRemove);
            }
            eventEntity.TicketsCount = eventEntity.TicketsCount - ticketsToRemove.Count;
        }
        else if (eventEntity.TicketsCount < request.TicketCount)
        {
            var ticketAddRequests = Enumerable.Range(0, request.TicketCount - eventEntity.TicketsCount)
                .Select(_ => new TicketAddRequest { EventId = eventEntity.Id })
                .ToList();

            await _ticketService.CreateTicketsAsync(ticketAddRequests);
            eventEntity.TicketsCount = request.TicketCount;
        }

        // Обновляем изображения
        if (request.Images.Any())
        {
            var existingImageIds = await _context.Images
                .Where(i => i.EntityId == id.ToString())
                .Select(i => i.Id)
                .ToListAsync();

            foreach (var imageRequest in request.Images)
            {
                if (imageRequest.Id != Guid.Empty && existingImageIds.Contains(imageRequest.Id))
                {
                    Image? image = await _context.Images.FirstOrDefaultAsync(i => i.Id == imageRequest.Id);
                    if (image != null)
                    {
                        image.LocalOrderRank = imageRequest.LocalOrderRank;
                        _context.Images.Update(image);
                        await _context.SaveChangesAsync();
                    }
                    existingImageIds.Remove(imageRequest.Id);
                }
                else if (imageRequest.Image != null)
                {
                    // Добавляем новое изображение
                    await _imageService.AddUploadedImageAsync(new ImageAddRequest
                    {
                        Image = imageRequest.Image,
                        LocalOrderRank = imageRequest.LocalOrderRank,
                        EntityTarget = "event",
                        EntityId = id.ToString()
                    });
                }
            }

            // Удаляем изображения, которых нет в запросе
            if (existingImageIds.Any())
            {
                await _imageService.RemoveImages(existingImageIds);
            }
        }

        _context.Events.Update(eventEntity);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success(true);
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
