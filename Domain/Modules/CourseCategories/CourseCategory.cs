using System.ComponentModel.DataAnnotations.Schema;
using Cerualean.Domain.CourseModule;

namespace Cerualean.Domain.Modules.CourseCategories
{
    [Table("course_category")]
    public class CourseCategory
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public required string Title { get; set; }
        [Column("description")]
        public string? Description { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}