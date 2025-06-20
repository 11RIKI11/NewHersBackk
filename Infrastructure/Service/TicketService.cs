﻿using AutoMapper;
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
using System.Linq.Expressions;
using System.Numerics;

namespace Infrastructure.Service;

public class TicketService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly PaymentService _paymentService;
    private readonly AttendeeService _attendeeService;

    public TicketService(ApplicationDbContext context, IMapper mapper, PaymentService paymentService, AttendeeService attendeeService)
    {
        _context = context;
        _mapper = mapper;
        _paymentService = paymentService;
        _attendeeService = attendeeService;
    }

    // Получить билет по Id
    public async Task<ServiceResult<TicketResponse>> GetTicketByIdAsync(Guid id)
    {
        var ticketEntity = await _context.Tickets
            .Include(t => t.Attendee)
            .Include(t => t.Event)
            .Include(t => t.Payment)
            .ThenInclude(p => p.Buyer)
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
            .Include(t => t.Event)
            .Include(t => t.Payment)
            .ThenInclude(p => p.Buyer)
            .Where(t => t.Payment == null ? true : t.Payment.BuyerId == userId);
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
        };

        await _context.Tickets.AddAsync(ticketEntity);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<TicketResponse>(ticketEntity);
        return ServiceResult<TicketResponse>.Success(response);
    }

    public async Task<ServiceResult<SearchResultResponse<TicketResponse>>> CreateTicketsAsync(List<TicketAddRequest> requests)
    {
        var tickets = requests
            .Select(r => new Ticket() { EventId = r.EventId, QRCode = string.Empty })
            .ToList();

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
        var ticketEntity = await _context.Tickets
            .Include(t => t.Payment)
            .Include(t => t.Event)
            .Include(t => t.Attendee)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (ticketEntity == null)
            return ServiceResult<bool>.Failure("Билет с таким Id не найден", 404);

        var eventEntity = ticketEntity.Event;
        if (eventEntity == null)
            return ServiceResult<bool>.Failure("Событие не найдено", 404);

        // Проверка времени события
        if (eventEntity.StartTime <= DateTime.UtcNow)
            return ServiceResult<bool>.Failure("Невозможно обновить билет - событие уже началось", 409);
            
        if (eventEntity.EndTime <= DateTime.UtcNow) 
            return ServiceResult<bool>.Failure("Невозможно обновить билет - событие уже завершилось", 409);

        var paymentEntity = ticketEntity.Payment;

        if (paymentEntity == null)
        {
            paymentEntity = (await _context.Tickets
                .Include(t => t.Payment)
                .Include(t => t.Event)
                .Include(t => t.Attendee)
                .FirstOrDefaultAsync(t => t.EventId == ticketEntity.EventId &&
            t.Payment != null && t.Payment.Status.ToLower() == PaymentStatus.WaitingForPayment.ToString().ToLower() &&
            t.Payment.BuyerId == request.UserId))?.Payment;
            if (paymentEntity != null)
            {
                paymentEntity.Amount += eventEntity.Price;
                paymentEntity.Tickets.Add(ticketEntity);
            }
        }

        if (paymentEntity == null && request.UserId != null)
        {
            var paymentAddRequest = new PaymentAddRequest
            {
                BuyerId = request.UserId,
                Amount = eventEntity.Price,
                TicketIds = new List<Guid> { ticketEntity.Id }
            };
            var paymentResponse = await _paymentService.CreatePaymentAsync(paymentAddRequest);
            if (!paymentResponse.IsSuccess)
                return ServiceResult<bool>.Failure(paymentResponse.Error.ErrorMessage, paymentResponse.Error.StatusCode);
        }

        if (request.UserId == null)
            ticketEntity.Payment = null;

        if (request.AttendeeId == null)
            ticketEntity.AttendeeId = null;
        else
        {
            ticketEntity.AttendeeId = request.AttendeeId.Value;
            var userAttendeeEntity = await _context.UserAttendees.FirstOrDefaultAsync(ua => ua.AttendeeId == request.AttendeeId.Value
            && ua.UserId == request.UserId);
            if (userAttendeeEntity == null && request.UserId != null)
            {
                var userAttendee = new UserAttendee
                {
                    AttendeeId = request.AttendeeId.Value,
                    UserId = request.UserId
                };
                await _context.UserAttendees.AddAsync(userAttendee);
            }
        }
            

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
            .Include(t => t.Event)
            .Include(t => t.Payment)
                .ThenInclude(p => p.Buyer)
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
                .Where(t => t.Payment != null)
                .Where(t => request.Filter.BuyerIds.Contains(t.Payment.BuyerId));

        if (request.Filter.PaymentIds.Count > 0)
            query = query
                .Where(t => t.PaymentId != null)
                .Where(t => request.Filter.PaymentIds.Contains(t.PaymentId.Value));

        if (!string.IsNullOrEmpty(request.Filter.BuyerName))
            query = query.Where(a => a.Payment == null ? false :
            EF.Functions.ILike(a.Payment.Buyer.FullName, $"{request.Filter.BuyerName}%") ||
            EF.Functions.ILike(a.Payment.Buyer.FullName, $" %{request.Filter.BuyerName}")
            );

        if (!string.IsNullOrEmpty(request.Filter.AttendeeName))
            query = query.Where(a => a.Attendee == null ? false :
            EF.Functions.ILike(a.Attendee.FullName, $"{request.Filter.AttendeeName}%") ||
            EF.Functions.ILike(a.Attendee.FullName, $" %{request.Filter.AttendeeName}")
            );

        var temp = await query.ToListAsync();

        if (request.Sort != null && request.Sort.Any())
        {
            IOrderedQueryable<Ticket>? orderedQuery = null;

            foreach (var sort in request.Sort)
            {
                var isFirstSort = orderedQuery == null;
                var isDescending = sort.SortDirection?.ToLower() == "desc";

                Expression<Func<Ticket, object>> orderByExpression = sort.SortBy?.ToLower() switch
                {
                    "id" => t => t.Id,
                    "eventtitle" => t => t.Event.Title,
                    "eventid" => t => t.Event.Id,
                    "eventdate" => t => t.Event.StartTime,
                    "eventprice" => t => t.Event.Price,
                    "attendeename" => t => t.Attendee != null ? t.Attendee.FullName : "",
                    "paymentstatus" => t => t.Payment != null ? t.Payment.Status : "",
                    "paymentdate" => t => t.Payment != null ? t.Payment.CreatedAt : DateTime.MinValue,
                    "buyername" => t => t.Payment != null ? t.Payment.Buyer.FullName : "",
                    "qrcode" => t => t.QRCode,
                    _ => t => t.Id
                };

                orderedQuery = isFirstSort
                    ? isDescending
                        ? query.OrderByDescending(orderByExpression)
                        : query.OrderBy(orderByExpression)
                    : isDescending
                        ? orderedQuery!.ThenByDescending(orderByExpression)
                        : orderedQuery!.ThenBy(orderByExpression);
            }

            query = orderedQuery ?? query;
        }

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


    public async Task<ServiceResult<List<Guid>>> ReserveTicketAsync(ReserveTicketRequest request)
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == request.EventId);
        if (eventEntity == null)
        {
            return ServiceResult<List<Guid>>.Failure("Событие не найдено", 404);
        }
        var tickets = await _context.Tickets
            .Include(t => t.Payment)
            .ThenInclude(p => p.Buyer)
            .Where(t => t.EventId == request.EventId && t.Payment == null)
            .ToListAsync();
        if (tickets.Count() < request.Attendees.Count)
            return ServiceResult<List<Guid>>.Failure("Свободных билетов нет или недостаточно", 404);
        List<AttendeeResponse> attendeeList = new List<AttendeeResponse>();

        var attendeeCreateResult = await _attendeeService.CreateAttendeeRangeAsync(request.UserId, request.Attendees);

        if (!attendeeCreateResult.IsSuccess)
        {
            return ServiceResult<List<Guid>>.Failure("Ошибка при создании посетителя: "
                + attendeeCreateResult.Error.ErrorMessage, attendeeCreateResult.Error.StatusCode);
        }
        attendeeList = attendeeCreateResult.Data;

        var reservedTicketIds = new List<Guid>();
        for (int i = 0; i < attendeeList.Count; i++)
        {
            var ticket = tickets[i];
            var attendee = attendeeList[i];

            ticket.AttendeeId = attendee.Id;
            reservedTicketIds.Add(ticket.Id);
        }

        var reserveTicket = await _context.Tickets
            .Include(t => t.Payment)
            .Include(t => t.Event)
            .Include(t => t.Attendee)
            .FirstOrDefaultAsync(t => t.EventId == request.EventId && t.Payment != null
            && t.Payment.Status.ToLower() == PaymentStatus.WaitingForPayment.ToString().ToLower()
            && t.Payment.BuyerId == request.UserId);

        if (reserveTicket != null)
        {
            foreach (var ticket in tickets)
            {
                ticket.Payment = reserveTicket.Payment;
                ticket.Payment.Amount += eventEntity.Price;
            }
        }
        else
        {
            PaymentAddRequest addRequest = new PaymentAddRequest
            {
                BuyerId = request.UserId,
                Amount = reservedTicketIds.Count * eventEntity.Price,
                TicketIds = reservedTicketIds
            };
            await _paymentService.CreatePaymentAsync(addRequest);
        }
        await _context.SaveChangesAsync();
        return ServiceResult<List<Guid>>.Success(reservedTicketIds);
    }

    public async Task<ServiceResult<int>> GetAvailableTicketsCountAsync(Guid eventId)
    {
        var availableTickets = await _context.Tickets
            .Include(t => t.Payment)
            .Where(t => t.EventId == eventId && t.Payment == null).ToListAsync();
        var count = availableTickets.Count();
        return ServiceResult<int>.Success(count);
    }

    public async Task<ServiceResult<bool>> CancelReserveTicketsAsync(Guid userId, Guid eventId)
    {
        // Проверяем существование мероприятия
        var eventEntity = await _context.Events.FindAsync(eventId);
        if (eventEntity == null)
            return ServiceResult<bool>.Failure("Мероприятие не найдено", 404);

        // Проверяем, не истекло ли время для отмены
        if (eventEntity.StartTime < DateTime.UtcNow || eventEntity.EndTime < DateTime.UtcNow)
            return ServiceResult<bool>.Failure("Период бронирования билетов завершился", 409);

        // Находим платеж пользователя
        var payment = await _context.Payments
            .Include(p => p.Tickets)
            .FirstOrDefaultAsync(p => p.BuyerId == userId
                && p.Tickets.Any(t => t.EventId == eventId)
                && p.Status.ToLower() == PaymentStatus.WaitingForPayment.ToString().ToLower());

        if (payment == null)
            return ServiceResult<bool>.Success();

        // Очищаем данные для всех билетов в платеже
        foreach (var ticket in payment.Tickets)
        {
            ticket.AttendeeId = null;
            ticket.PaymentId = null;
        }

        // Удаляем платеж
        _context.Payments.Remove(payment);

        await _context.SaveChangesAsync();
        return ServiceResult<bool>.Success();
    }
}

