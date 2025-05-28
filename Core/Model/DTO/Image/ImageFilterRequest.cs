using Core.ValidateAttribute;
using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO.Image;

public class ImageFilterRequest
{
    public List<Guid> ImageIds { get; set; } = new List<Guid>();
    
    [StringLengthIfNotNull(50)]
    public string? ImageType { get; set; } = null;
}
