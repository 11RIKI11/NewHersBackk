namespace Core.Model.DTO.User;

public class UserSearchRequest
{
    public UserFilterRequest Filter { get; set; } = new UserFilterRequest();
    public List<SortRequest> Sort { get; set; } = new List<SortRequest>();
    public PaginationRequest Pagination { get; set; } = new PaginationRequest();
}

