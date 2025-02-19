using Cerualean.Domain.CourseCategoryModule.Dtos;

namespace Cerualean.Domain.CourseCategoryModule
{
    public static class CourseCategoryMappers
    {
        public static CourseCategoryDto ToCourseCategoryDto
        (
            this CourseCategory courseCategory
        )
        {
            return new CourseCategoryDto
            {
                Title = courseCategory.Title,
                Description = courseCategory.Description
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