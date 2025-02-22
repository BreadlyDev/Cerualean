namespace Cerualean.Domain.Modules.CourseCategories.Dtos
{
    public class CreateCourseCategoryDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}