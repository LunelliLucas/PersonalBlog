using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonalBlog.DTOs
{
    public class ArticleDTO
    {
        [Key]
        public int ArticleId { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Tag { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }
    }
}
