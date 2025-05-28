using System.ComponentModel.DataAnnotations;

namespace Core.Model.DTO;

public class SortRequest
{
    [Required(ErrorMessage = "SortBy is required")]
    public string SortBy { get; set; }

    [Required(ErrorMessage = "SortDirection is required")]
    [RegularExpression(@"^(asc|desc)$", ErrorMessage = "SortDirection must be either 'asc' or 'desc'")]
    public string SortDirection { get; set; }
}

