using Core.ValidateAttribute;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Event;
public class EventImageAddRequest
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Images is required.")]
    [FileExtensions(Extensions = "jpg,jpeg,png,gif,bmp", ErrorMessage = "Only image files (jpg, jpeg, png, gif, bmp) are allowed.")]
    public IFormFile Image { get; set; }

    [Required(ErrorMessage = "LocalOrderRank is required.")]
    public short LocalOrderRank { get; set; } = 0;
}

