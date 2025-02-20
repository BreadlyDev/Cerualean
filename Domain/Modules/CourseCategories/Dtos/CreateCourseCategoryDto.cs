using System.ComponentModel.DataAnnotations;

namespace Cerualean.Domain.Modules.CourseCategories.Dtos
{
    public class CreateCourseCategoryDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}