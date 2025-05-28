using Core.Model.DTO.Image;

namespace Core.Model.DTO.Event;

public class EventImageUpdateRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    public ImageUpdateRequest Image { get; set; } = new ImageUpdateRequest();
}

