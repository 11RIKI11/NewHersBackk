using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Enums;

namespace Core.Model.Entities
{
    public class Image
    {
        [Key] public Guid Id { get; set; }

        [Required] public string ImageUrl { get; set; } = string.Empty;

        [Required] public string ImageType { get; set; }
        [Required] public short LocalOrderRank { get; set; } = 0;
        [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? EntityId { get; set; } = null;
        public string? EntityTarget { get; set; } = null;
    }
}
