using System.ComponentModel.DataAnnotations.Schema;
using Cerualean.Domain.Modules.CourseCategories;

namespace Cerualean.Domain.CourseModule
{
    [Table("course")]
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Duration { get; set; }
        public double Price { get; set; }
        public CourseCategory Category { get; set; }
        public int CategoryId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now.ToUniversalTime();
    }
}