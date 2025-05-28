namespace Core.Model.DTO.Image;

public class ImageResponse
{
    public Guid Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public string ImageType { get; set; } = string.Empty; // e.g., "page.top"
    public string EntityId { get; set; } = string.Empty;
    public string Entity { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public short LocalOrderRank { get; set; } = 0;
}
