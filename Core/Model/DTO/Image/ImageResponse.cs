namespace Core.Model.DTO.Image;

public class ImageResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string ImageType { get; set; } = string.Empty; // e.g., "page.top"
    public short LocalOrderRank { get; set; } = 0;
}
