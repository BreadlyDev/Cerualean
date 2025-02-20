using Cerualean.Domain.CourseCategoryModule.Dtos;

namespace Cerualean.Domain.CourseCategoryModule.Helpers
{
    public static class CourseCategoryMapper
    {
        public static CourseCategoryDto ToCourseCategoryDto
        (
            this CourseCategory courseCategory
        )
        {
            return new CourseCategoryDto
            {
                Id = courseCategory.Id,
                Title = courseCategory.Title,
                Description = courseCategory.Description == null ? 
                "" : courseCategory.Description
            };
        }

        public static CourseCategory ToCourseCategoryFromCategoryDto
        (
            this CourseCategoryDto courseCategoryDto
        )
        {
            return new CourseCategory
            {
                Title = courseCategoryDto.Title,
                Description = courseCategoryDto.Description
            };
        }

        public static CourseCategory ToCourseCategoryFromCreateDto
        (
            this CreateCourseCategoryDto courseCategoryDto
        )
        {
            return new CourseCategory
            {
                Title = courseCategoryDto.Title,
                Description = courseCategoryDto.Description                
            };
        }
        public static CourseCategory ToCourseCategoryFromUpdateDto
        (
            this UpdateCourseCategoryDto courseCategoryDto
        )
        {
            return new CourseCategory
            {
                Title = courseCategoryDto.Title,
                Description = courseCategoryDto.Description                
            };
        }
    }
}