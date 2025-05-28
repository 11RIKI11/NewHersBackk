using Core.Attribute;
using Core.Model.DTO.Attendee;
using Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiVersion("1.0")]
    public class AttendeesController : CustomControllerBase
    {
        private readonly AttendeeService _attendeeService;
        public AttendeesController(AttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetAttendeeById(Guid id)
        {
            var result = await _attendeeService.GetAttendeeById(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetAllAttendees([FromBody] AttendeeSearchRequest request)
        {
            var result = await _attendeeService.GetAttendeesAsync(request);

            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAttendeeById(Guid id, [FromBody] AttendeeUpdateRequest request)
        {
            var result = await _attendeeService.UpdateAttendeeAsync(id, request);
            if (!result.IsSuccess) 
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAttendee (Guid id)
        {
            var result = await _attendeeService.DeleteAttendeeByIdAsync(id);
            if(!result.IsSuccess) 
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpPost]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAttendee([FromQuery]Guid userId, [FromBody] AttendeeAddRequest request) 
        {
            var result = await _attendeeService.CreateAttendeeAsync(userId, request);
            if (!result.IsSuccess) 
                return BadRequestResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("me")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> CreateAttendeeSelf([FromBody] AttendeeAddRequest request) 
        {
            var result = await _attendeeService.CreateAttendeeAsync(UserId.Value, request);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("me/search/by-event/{EventId:guid}")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetMyAttendeesByEventId(Guid eventId, [FromBody] AttendeeSearchRequest request)
        {
            var result = await _attendeeService.GetAttendeesByUserByEventAsync(UserId.Value, eventId, request);
            if (!result.IsSuccess) 
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost("me/search")]
        [ValidateModel]
        [ValidateToken]
        [Authorize(Roles = "user")]
        public async Task<IActionResult> GetMyAttendees([FromBody] AttendeeSearchRequest request)
        {
            var result = await _attendeeService.GetAttendeesByUserAsync(UserId.Value, request);
            if (!result.IsSuccess) 
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        //TODO 

    }
}
