namespace Core.Model.DTO.Image;

public class ImageSearchRequest
{
    public ImageFilterRequest Filter { get; set; } = new ImageFilterRequest();
    public List<SortRequest> Sort { get; set; } = new List<SortRequest>();
    public PaginationRequest Pagination { get; set; } = new PaginationRequest();
}

