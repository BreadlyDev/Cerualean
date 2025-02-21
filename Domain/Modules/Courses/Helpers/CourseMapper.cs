using Cerualean.Domain.CourseModule.Dtos;

namespace Cerualean.Domain.CourseModule.Helpers
{
    public static class CourseMapper
    {
        public static CourseDto ToCourseDto(this Course courseModel) 
        {
            return new CourseDto 
            {
                Id = courseModel.Id,
                Title = courseModel.Title,
                Description = courseModel.Description,
                Duration = courseModel.Duration,
                CategoryId = courseModel.CategoryId,
                Price = courseModel.Price,
                CreatedTime = courseModel.CreatedTime
            };
        }

        public static Course ToCourseFromCourseDto(this CourseDto courseDto) 
        {
            return new Course 
            {
                Id = courseDto.Id,
                Title = courseDto.Title,
                Description = courseDto.Description,
                Duration = courseDto.Duration,
                CategoryId = courseDto.CategoryId,
                Price = courseDto.Price,
                CreatedTime = courseDto.CreatedTime
            };
        }

        public static Course ToCourseFromCreateDto(this CreateCourseDto courseDto, int categoryId)
        {
            return new Course 
            {
                CategoryId = categoryId,
                Title = courseDto.Title,
                Description = courseDto.Description,
                Duration = courseDto.Duration,
                Price = courseDto.Price
            };
        }

        public static Course ToCourseFromUpdateDto(this UpdateCourseDto courseDto)
        {
            return new Course 
            {
                CategoryId = courseDto.CategoryId,
                Title = courseDto.Title,
                Description = courseDto.Description,
                Duration = courseDto.Duration,
                Price = courseDto.Price
            };
        }
    }
}