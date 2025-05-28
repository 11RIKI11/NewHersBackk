using Core.Model.DTO;
using Core.Model.DTO.Image;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace BackendApp.Controllers
{
    [ApiVersion("1.0")]
    public class ImagesController : CustomControllerBase
    {
        private ImageService _imageService;
        public ImagesController(ImageService imageService)
        {
            _imageService = imageService;
        }

        // Получить изображение по Id
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var result = await _imageService.GetImageByIdAsync(id);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        // Получить изображение по типу
        [HttpPost("search/by-type")]
        public async Task<IActionResult> GetImagesByType([FromQuery] string imageType, [FromBody] PaginationRequest pagination)
        {
            var result = await _imageService.GetImagesByTypeAsync(imageType, pagination);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] ImageAddRequest request)
        {
            var result = await _imageService.AddUploadedImageAsync(request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return OkResponse(result.Data);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var result = await _imageService.RemoveImages([id]);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateImage(Guid id, [FromBody] ImageUpdateRequest request)
        {
            var result = await _imageService.UpdateImageAsync(id, request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpPut("by-type/{imageType}")]
        public async Task<IActionResult> UpdateImagesByType(string imageType, [FromBody] ImageUpdateRequest request)
        {
            var result = await _imageService.UpdateImagesByTypeAsync(imageType, request);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }

        [HttpDelete("by-type/{imageType}")]
        public async Task<IActionResult> DeleteImagesByType(string imageType)
        {
            var result = await _imageService.RemoveImagesByTypeAsync(imageType);
            if (!result.IsSuccess)
                return NotFoundResponse(result.Error.ErrorMessage);
            return NoContent();
        }
    }
}
