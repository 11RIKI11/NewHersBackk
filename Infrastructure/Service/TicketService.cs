using AutoMapper;
using AutoMapper.Configuration.Annotations;
using Core.Enums;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Payment;
using Core.Model.DTO.Ticket;
using Core.Model.Entities;
using Core.Results;
using Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Infrastructure.Service;

public class TicketService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public TicketService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Получить билет по Id
    public async Task<ServiceResult<TicketResponse>> GetTicketByIdAsync(Guid id)
    {
        var ticketEntity = await _context.Tickets
            .Include(t => t.Attendee)
            .Include(t => t.Buyer)
            .Include(t => t.Event)
            .Include(t => t.Payment)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticketEntity == null)
            return ServiceResult<TicketResponse>.Failure("Билет с таким Id не найден", 404);
        var response = _mapper.Map<TicketResponse>(ticketEntity);
        return ServiceResult<TicketResponse>.Success(response);
    }

    public async Task<ServiceResult<SearchResultResponse<TicketResponse>>> GetTicketsByUserIdAsync(Guid userId, PaginationRequest pag)
    {

        var ticketEntities = _context.Tickets
            .Include(t => t.Attendee)
            .Include(t => t.Buyer)
            .Include(t => t.Event)
            .Include(t => t.Payment)
            .Where(t => t.BuyerId == userId);
        var totalCount = await ticketEntities.CountAsync();
        var tickets = await ticketEntities
            .Paginate(pag.Page, pag.PageSize)
            .ToListAsync();
        var result = new SearchResultResponse<TicketResponse>
        {
            Items = _mapper.Map<List<TicketResponse>>(tickets),
            TotalCount = totalCount
        };

        return ServiceResult<SearchResultResponse<TicketResponse>>.Success(result);
    }

    public async Task<ServiceResult<SearchResultResponse<TicketResponse>>> GetTicketsByEventIdAsync(Guid eventId, PaginationRequest pag)
    {
        var ticketEntities = _context.Tickets
            .Include(t => t.Attendee)
            .Include(t => t.Buyer)
            .Include(t => t.Event)
            .Include(t => t.Payment)
            .Where(t => t.EventId == eventId);
        var totalCount = await ticketEntities.CountAsync();
        var tickets = await ticketEntities
            .Paginate(pag.Page, pag.PageSize)
            .ToListAsync();
        var result = new SearchResultResponse<TicketResponse>
        {
            Items = _mapper.Map<List<TicketResponse>>(tickets),
            TotalCount = totalCount
        };

        return ServiceResult<SearchResultResponse<TicketResponse>>.Success(result);
    }

    //Добавление
    public async Task<ServiceResult<TicketResponse>> CreateTicketAsync(TicketAddRequest ticketRequest)
    {

        var ticketEntity = new Ticket
        {
            EventId = ticketRequest.EventId,
            QRCode = string.Empty,//автомат генерация qrCode todo
            Status = TicketStatus.Available.ToString().ToLower()
        };

        await _context.Tickets.AddAsync(ticketEntity);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<TicketResponse>(ticketEntity);
        return ServiceResult<TicketResponse>.Success(response);
    }

    public async Task<ServiceResult<SearchResultResponse<TicketResponse>>> CreateTicketsAsync(List<TicketAddRequest> requests)
    {
        var tickets = new List<Ticket>();
        foreach (var request in requests)
        {
            tickets.Add(new Ticket
            {
                EventId = request.EventId,
                QRCode = string.Empty,//автомат генерация qrCode todo
                Status = TicketStatus.Available.ToString().ToLower()
            });
        }

        await _context.Tickets.AddRangeAsync(tickets);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<List<TicketResponse>>(tickets);

        var result = new SearchResultResponse<TicketResponse>
        {
            Items = response,
            TotalCount = tickets.Count
        };

        return ServiceResult<SearchResultResponse<TicketResponse>>.Success(result);
    }

    public async Task<ServiceResult<bool>> UpdateTicketAsync(Guid id, TicketUpdateRequest request)
    {
        var ticketEntity = await _context.Tickets.FindAsync(id);
        if (ticketEntity == null)
            return ServiceResult<bool>.Failure("Билет с таким Id не найден", 404);

        ticketEntity.Status = request.Status.ToString().ToLower();
        //Без обновления кьюаркода?
        //if (request.ContactPhone != null)
        //    ticketEntity.ContactPhone = request.ContactPhone;
        if (request.AttendeeId == null)
            ticketEntity.AttendeeId = request.AttendeeId;
        else
            ticketEntity.AttendeeId = request.AttendeeId.Value;
        if (request.BuyerId == null)
            ticketEntity.BuyerId = request.BuyerId;
        else
            ticketEntity.BuyerId = request.BuyerId.Value;
        if (request.PaymentId == null)
            ticketEntity.PaymentId = request.PaymentId;
        else
            ticketEntity.PaymentId = request.PaymentId.Value;
        ticketEntity.QRCode = request.QrCode;

        _context.Tickets.Update(ticketEntity);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> DeleteTicketAsync(Guid id)
    {
        var ticketEntity = await _context.Tickets.FindAsync(id);
        if (ticketEntity == null)
            return ServiceResult<bool>.Failure("Билет с таким Id не найден", 404);

        _context.Tickets.Remove(ticketEntity);
        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<SearchResultResponse<TicketResponse>>> GetTicketsAsync(TicketSearchRequest request)
    {
        var query = _context.Tickets
            .Include(t => t.Attendee)
            .Include(t => t.Buyer)
            .Include(t => t.Event)
            .Include(t => t.Payment)
            .AsQueryable();

        if (request.Filter.TicketIds.Count > 0)
            query = query.Where(a => request.Filter.TicketIds.Contains(a.Id));

        if (request.Filter.EventIds.Count > 0)
            query = query
                .Where(a => request.Filter.EventIds.Contains(a.EventId));

        if (request.Filter.AttendeeIds.Count > 0)
            query = query
                .Where(t => t.AttendeeId != null)
                .Where(t => request.Filter.AttendeeIds.Contains(t.AttendeeId.Value));

        if (request.Filter.BuyerIds.Count > 0)
            query = query
                .Where(t => t.BuyerId != null)
                .Where(t => request.Filter.BuyerIds.Contains(t.BuyerId.Value));

        if (request.Filter.PaymentIds.Count > 0)
            query = query
                .Where(t => t.PaymentId != null)
                .Where(t => request.Filter.PaymentIds.Contains(t.PaymentId.Value));

        if (!string.IsNullOrEmpty(request.Filter.BuyerName))
            query = query.Where(a =>
            EF.Functions.ILike(a.Buyer.FullName, $"{request.Filter.BuyerName}%") ||
            EF.Functions.ILike(a.Buyer.FullName, $" %{request.Filter.BuyerName}")
            );

        if (!string.IsNullOrEmpty(request.Filter.AttendeeName))
            query = query.Where(a =>
            EF.Functions.ILike(a.Attendee.FullName, $"{request.Filter.AttendeeName}%") ||
            EF.Functions.ILike(a.Attendee.FullName, $" %{request.Filter.AttendeeName}")
            );

        var total = await query.CountAsync();

        var tickets = await query
            .Paginate(request.Pagination.Page, request.Pagination.PageSize)
            .ToListAsync();

        var result = new SearchResultResponse<TicketResponse>
        {
            Items = _mapper.Map<List<TicketResponse>>(tickets),
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<TicketResponse>>.Success(result);
    }

    public async Task<ServiceResult<Guid>> ReserveTicketAsync(Guid userId, Guid eventId)
    {
        var eventEntity = await _context.Events.FindAsync(eventId);
        if (eventEntity == null)
            return ServiceResult<Guid>.Failure("Мероприятие не найдено", 404);
        if (eventEntity.StartTime < DateTime.UtcNow || eventEntity.EndTime < DateTime.UtcNow)
            return ServiceResult<Guid>.Failure("Переиод бронирования билетов завершился", 409);
        var ticket = await _context.Tickets.Where(t => t.EventId == eventId &&( t.Status == TicketStatus.Available.ToString().ToLower()
        || t.Status == TicketStatus.Available.ToString())).FirstOrDefaultAsync();
        if (ticket == null)
            return ServiceResult<Guid>.Failure("Свободных билетов на это событие не найдено", 409);
        ticket.Status = TicketStatus.Reserved.ToString().ToLower();
        ticket.BuyerId = userId;
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ServiceResult<Guid>.Success(ticket.Id);
    }

    public async Task<ServiceResult<int>> GetAvailableTicketsCountAsync(Guid eventId)
    {
        var count = await _context.Tickets.Where(t => t.EventId == eventId && (t.Status == TicketStatus.Available.ToString().ToLower() 
        || t.Status == TicketStatus.Available.ToString())).CountAsync();
        return ServiceResult<int>.Success(count);
    }

    public async Task<ServiceResult<bool>> CancelReserveTicketAsync(Guid userId, Guid eventId)
    {
        var eventEntity = await _context.Events.FindAsync(eventId);
        if (eventEntity == null)
            return ServiceResult<bool>.Failure("Мероприятие не найдено", 404);
        if (eventEntity.StartTime < DateTime.UtcNow || eventEntity.EndTime < DateTime.UtcNow)
            return ServiceResult<bool>.Failure("Переиод бронирования билетов завершился", 409);

        var tickets = await _context.Tickets
            .Where(t => t.EventId == eventId && (t.Status ==TicketStatus.Reserved.ToString().ToLower() 
            || t.Status == TicketStatus.Reserved.ToString()) && t.BuyerId == userId)
            .ToListAsync();
        if (tickets == null || tickets.Count == 0)
            return ServiceResult<bool>.Failure("Билеты не найдены", 404);
        foreach (var ticket in tickets)
        {
            ticket.Status = TicketStatus.Available.ToString().ToLower();
            ticket.BuyerId = null;
        }

        _context.Tickets.UpdateRange(tickets);
        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }
}

