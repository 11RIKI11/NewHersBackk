namespace Core.Model.DTO;

public class SearchResultResponse<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int TotalCount { get; set; } = 0;
}

