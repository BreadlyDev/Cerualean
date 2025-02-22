using System.ComponentModel.DataAnnotations.Schema;
using Cerualean.Domain.Modules.CourseCategories;

namespace Cerualean.Domain.CourseModule
{
    [Table("course")]
    public class Course
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public required string Title { get; set; }
        [Column("desсription")]
        public string? Description { get; set; } = string.Empty;
        [Column("duration")]
        public required string Duration { get; set; }
        [Column("price")]
        public double Price { get; set; }
        public CourseCategory Category { get; set; } = null!;
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("created_time")]
        public DateTime CreatedTime { get; set; } = DateTime.Now.ToUniversalTime();
    }
}