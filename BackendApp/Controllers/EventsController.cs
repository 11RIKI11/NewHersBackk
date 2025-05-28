using Core.Attribute;
using Core.Model.DTO.Event;
using Core.Model.DTO.Image;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiVersion("1.0")]
    public class EventsController : CustomControllerBase
    {
        private EventService _eventService;
        public EventsController(EventService eventService)
        {
            _eventService = eventService;
        }
        // Получить событие по Id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var result = await _eventService.GetEventByIdAsync(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        // Получить список событий с пагинацией
        [HttpPost("search")]
        [ValidateModel]
        public async Task<IActionResult> GetEvents([FromBody] EventSearchRequest request)
        {
            var result = await _eventService.GetEventsAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateEvent([FromBody] EventAddRequest request)
        {
            var result = await _eventService.CreateEventAsync(request);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }
        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateEvent(Guid id, [FromBody] EventUpdateRequest request)
        {
            var result = await _eventService.UpdateEventAsync(id, request);
            if (!result.IsSuccess)
                return BadRequestResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            var result = await _eventService.DeleteEventAsync(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }
    }
}
