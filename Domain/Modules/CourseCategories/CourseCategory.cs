using System.ComponentModel.DataAnnotations.Schema;
using Cerualean.Domain.CourseModule;

namespace Cerualean.Domain.Modules.CourseCategories
{
    [Table("course_category")]
    public class CourseCategory
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}