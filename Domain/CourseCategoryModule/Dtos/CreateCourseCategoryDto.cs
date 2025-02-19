using System.ComponentModel.DataAnnotations;

namespace Cerualean.Domain.CourseCategoryModule.Dtos
{
    public class CreateCourseCategoryDto
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}