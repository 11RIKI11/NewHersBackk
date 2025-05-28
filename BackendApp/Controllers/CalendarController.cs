using Core.Attribute;
using Core.Model.DTO;
using Core.Model.DTO.UserEventCalendar;
using Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiVersion("1.0")]
    public class CalendarController : CustomControllerBase
    {
        private UserEventCalendarService _userEventCalendarService;
        public CalendarController(UserEventCalendarService userEventCalendarService)
        {
            _userEventCalendarService = userEventCalendarService;
        }

        [HttpGet("me")]
        [ValidateToken]
        public async Task<IActionResult> GetUserEventsBySelf([FromQuery]PaginationRequest pagination)
        {
            var result = await _userEventCalendarService.GetUserEventsByUserIdAsync(UserId.Value, pagination);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("user/{userId:guid}")]
        [ValidateModel]
        public async Task<IActionResult> AddUserEvent(Guid userId, [FromBody] UserCalendarAddEventRequest request)
        {
            var result = await _userEventCalendarService.AddUserCalendarEventAsync(userId, request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("me")]
        [ValidateModel]
        [ValidateToken]
        public async Task<IActionResult> AddUserEventBySelf([FromBody] UserCalendarAddEventRequest request)
        {
            return await AddUserEvent(UserId.Value, request);
        }

        [HttpDelete("{Id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUserEvent(Guid Id)
        {
            var result = await _userEventCalendarService.RemoveUserCalendarEventByIdAsync(Id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpDelete("by-event{eventId:guid}")]
        [ValidateModel]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUserEventByEvent([FromQuery]Guid userId, Guid eventId)
        {
            var result = await _userEventCalendarService.RemoveUserCalendarEventAsync(userId, eventId);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpDelete("me/by-event/{eventId:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> DeleteUserEventBySelfByEvent(Guid eventId)
        {
            return await DeleteUserEventByEvent(UserId.Value, eventId);
        }

        [HttpDelete("me/{userId:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> DeleteUserEventsBySelf(Guid userId)
        {
            var result = await _userEventCalendarService.RemoveAllEventsFromCalendarAsync(userId);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }


        [HttpPut("{Id:guid}")]
        [ValidateModel]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUserEvent(Guid Id, [FromBody] UserCalendarUpdateEventRequest request)
        {
            var result = await _userEventCalendarService.UpdateUserCalendarEventByIdAsync(Id, request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpPut("by-event/{eventId:guid}")]
        [ValidateModel]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateUserEventByEvent([FromQuery] Guid userId, Guid eventId, [FromBody] UserCalendarUpdateEventRequest request)
        {
            var result = await _userEventCalendarService.UpdateUserCalendarEventAsync(userId, eventId, request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpPut("me/{eventId:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> UpdateUserEventBySelf(Guid eventid, [FromBody] UserCalendarUpdateEventRequest request)
        {
            return await UpdateUserEventByEvent(UserId.Value, eventid, request);
        }
    }
}
