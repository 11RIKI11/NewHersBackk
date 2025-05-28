using System.ComponentModel.DataAnnotations;
namespace Core.Model.DTO;

public class PaginationRequest
{

    [Range(0, 1000, ErrorMessage = "Page must be between 1 and 1000")]
    public int Page { get; set; } = 1;
    [Range(1, 300, ErrorMessage = "PageSize must be between 1 and 300")]
    public int PageSize { get; set; } = 10;
}

