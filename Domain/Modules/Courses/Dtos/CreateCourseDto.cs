using System.ComponentModel.DataAnnotations;

namespace Cerualean.Domain.CourseModule.Dtos
{
    public class CreateCourseDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        [RegularExpression(@"\d{1,2}\s*(y|M|d|h|m)+$")]
        public required string Duration { get; set; }
        public double Price { get; set; }
    }
}