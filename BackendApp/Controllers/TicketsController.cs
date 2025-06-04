using Core.Attribute;
using Core.Model.DTO.Attendee;
using Core.Model.DTO.Ticket;
using Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiVersion("1.0")]
    public class TicketsController :CustomControllerBase
    {
        private TicketService _ticketService;
        public TicketsController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetTicketById(Guid id)
        {
            var result = await _ticketService.GetTicketByIdAsync(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("me")]
        [ValidateToken]
        public async Task<IActionResult> GetTicketsBySelf([FromBody] TicketSearchRequest request)
        {
            request.Filter.BuyerIds = new List<Guid> { UserId.Value };
            var result = await _ticketService.GetTicketsAsync(request);
            if(!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("search")]   
        [ValidateModel]
        public async Task<IActionResult> GetTickets([FromBody] TicketSearchRequest request)
        {
            var result = await _ticketService.GetTicketsAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> AddTicket([FromBody] TicketAddRequest request)
        {
            var result = await _ticketService.CreateTicketAsync(request);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateTicket(Guid id, [FromBody] TicketUpdateRequest request)
        {
            var result = await _ticketService.UpdateTicketAsync(id, request);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return NoContentResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            var result = await _ticketService.DeleteTicketAsync(id);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return NoContentResponse();
        }

        [HttpPost("reserve/{eventId:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> ReserveTicket([FromRoute] Guid eventId, [FromBody] List<AttendeeAddRequest>? requests)
        {
            if(requests == null)
                requests = new List<AttendeeAddRequest>();

            var request = new ReserveTicketRequest
            {
                UserId = UserId.Value,
                EventId = eventId,
                Attendees = requests
            };
            var result = await _ticketService.ReserveTicketAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("reserved/admin/by-event/{eventId:guid}/by-user/{userId:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ReserveTicketAdmin(Guid eventId, Guid userId, [FromBody] List<AttendeeAddRequest> requests)
        {
            var request = new ReserveTicketRequest
            {
                UserId = userId,
                EventId = eventId,
                Attendees = requests
            };
            var result = await _ticketService.ReserveTicketAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpGet("available/{Event:guid}")]
        public async Task<IActionResult> GetAvailableTicketsCount(Guid eventId)
        {
            var result = await _ticketService.GetAvailableTicketsCountAsync(eventId);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("cancel-reserve/{Event:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> CancelReserveTicket(Guid eventId)
        {
            var result = await _ticketService.CancelReserveTicketsAsync(UserId.Value, eventId);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContentResponse();
        }

        //TODO: Отмена брони, проверить, что этот пользователь и событие не прошло, билет не продан

    }
}
