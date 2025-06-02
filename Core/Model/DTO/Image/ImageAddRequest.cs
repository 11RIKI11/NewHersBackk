using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Core.ValidateAttribute;

namespace Core.Model.DTO.Image;

[EntityPairValidation("EntityId", "EntityTarget", "ImageType")]
public class ImageAddRequest
{
    [Required(ErrorMessage = "Images is required.")]
    [FileExtensions(Extensions = "jpg,jpeg,png,gif,bmp", ErrorMessage = "Only image files (jpg, jpeg, png, gif, bmp) are allowed.")]
    public IFormFile Image { get; set; }

    [StringLengthIfNotNull(50)]
    public string? ImageType { get; set; } = string.Empty; // e.g., "page.top"

    [Required(ErrorMessage = "LocalOrderRank is required.")]
    public short LocalOrderRank { get; set; } = 0;

    public string? EntityId { get; set; } = null;

    public string? EntityTarget { get; set; } = null; // e.g., "event"
}
