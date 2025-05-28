using AutoMapper;
using Core.Enums;
using Core.Extensions;
using Core.Model.DTO;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Payment;
using Core.Model.DTO.Ticket;
using Core.Model.Entities;
using Core.Results;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service;

public class PaymentService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PaymentService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResult<PaymentResponse>> CreatePaymentAsync(PaymentAddRequest request)
    {
        var payment = _mapper.Map<Payment>(request);
        
        var tickets = await _context.Tickets
            .Include(t => t.Payment)
            .Where(t => request.TicketIds.Contains(t.Id))
            .ToListAsync();

        // Проверяем что все запрошенные билеты существуют
        if (tickets.Count != request.TicketIds.Count)
        {
            var foundTicketIds = tickets.Select(t => t.Id);
            var missingTicketIds = request.TicketIds.Except(foundTicketIds);
            return ServiceResult<PaymentResponse>.Failure(
                $"Tickets with IDs {string.Join(", ", missingTicketIds)} not found", 404);
        }

        // Проверяем что ни один из билетов не привязан к другому платежу
        var ticketsWithPayment = tickets.Where(t => t.Payment != null).ToList();
        if (ticketsWithPayment.Any())
        {
            return ServiceResult<PaymentResponse>.Failure(
                $"Tickets with IDs {string.Join(", ", ticketsWithPayment.Select(t => t.Id))} already have payment", 409);
        }

        // Привязываем билеты к платежу
        foreach (var ticket in tickets)
        {
            ticket.Payment = payment;
        }

        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<PaymentResponse>(payment);
        return ServiceResult<PaymentResponse>.Success(response);
    }

    public async Task<ServiceResult<PaymentResponse>> GetPaymentByIdAsync(Guid id)
    {
        var payment = await _context.Payments
            .Include(p => p.Buyer)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (payment == null)
            return ServiceResult<PaymentResponse>.Failure("Оплата не найдена", 404);

        var response = _mapper.Map<PaymentResponse>(payment);

        return ServiceResult<PaymentResponse>.Success(response);
    }

    public async Task<ServiceResult<SearchResultResponse<PaymentResponse>>> GetPaymentsByUserIdAsync(Guid userId, PaginationRequest pag)
    {
        var payments = _context.Payments
            .Include(p => p.Buyer)
            .AsQueryable();
        payments = payments.Where(p => p.BuyerId == userId);
        var total = await payments.CountAsync();

        if (total == 0)
            return ServiceResult<SearchResultResponse<PaymentResponse>>.Failure("Оплата не найдена", 404);

        var paymentsList = await payments
            .Paginate(pag.Page, pag.PageSize)
            .ToListAsync();

        var responses = _mapper.Map<List<PaymentResponse>>(paymentsList);

        var result = new SearchResultResponse<PaymentResponse>
        {
            Items = responses,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<PaymentResponse>>.Success(result);
    }

    public async Task<ServiceResult<bool>> UpdatePaymentAsync(Guid id, PaymentUpdateRequest request)
    {
        var payment = await _context.Payments
            .Include(p => p.Buyer)
            .Where(p => p.Id == id).FirstOrDefaultAsync();

        if (payment == null)
            return ServiceResult<bool>.Failure("Payment not found", 404);
        payment.Status = request.Status.ToString().ToLower();
        payment.PaidAt = request.PaidAt;
        payment.QrUrl = request.QrUrl;

        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<bool>> DeletePaymentAsync(Guid id)
    {
        var payment = await _context.Payments.Where(p => p.Id == id).FirstOrDefaultAsync();

        if (payment == null)
            return ServiceResult<bool>.Failure("Payment not found", 404);

        _context.Payments.Remove(payment);

        await _context.SaveChangesAsync();

        return ServiceResult<bool>.Success();
    }

    public async Task<ServiceResult<SearchResultResponse<PaymentResponse>>> GetPaymentsAsync(PaymentSearchRequest request)
    {
        var query = _context.Payments
            .Include(p => p.Buyer)
            .AsQueryable();

        if (request.Filter.PaymentIds.Count > 0)
            query = query.Where(p => request.Filter.PaymentIds.Contains(p.Id)
            );//?
        
        if (request.Filter.UserIds.Count > 0)
            query = query.Where(p => request.Filter.UserIds.Contains(p.BuyerId)
            );//?

        if (request.Filter.MinAmount != null)
            query = query.Where(p => p.Amount == request.Filter.MinAmount);

        if (request.Filter.MaxAmount != null)
            query = query.Where(p => p.Amount == request.Filter.MaxAmount);

        var statuses = request.Filter.Status.Select(p => p.ToString().ToLower()).ToList();
        if (request.Filter.Status.Count > 0)
            query = query.Where(p => statuses.Contains(p.Status.ToLower()));

        if(request.Filter.CreatedAtFrom != null)
            query = query.Where(p => p.CreatedAt >= request.Filter.CreatedAtFrom);
        if(request.Filter.CreatedAtTo != null)
            query = query.Where(p => p.CreatedAt <= request.Filter.CreatedAtTo);

        if (request.Filter.PaidAtTo != null )
            query = query.Where(p => p.PaidAt <= request.Filter.PaidAtTo);

        if (request.Filter.PaidAtFrom != null)
            query = query.Where(p => p.PaidAt >= request.Filter.PaidAtFrom);

        query = SortingHelper.ApplySorting(query, request.Sort);

        // Пагинация

        var total = await query.CountAsync();

        var payments = await query
            .Paginate(request.Pagination.Page, request.Pagination.PageSize)
            .ToListAsync();

        var mappingPayments = _mapper.Map<List<PaymentResponse>>(payments);

        var result = new SearchResultResponse<PaymentResponse>
        {
            Items = mappingPayments,
            TotalCount = total
        };

        return ServiceResult<SearchResultResponse<PaymentResponse>>.Success(result);
    }
}

