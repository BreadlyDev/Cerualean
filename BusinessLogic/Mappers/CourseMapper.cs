using BusinessLogic.Dtos.Course;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class CourseMapper
{
    public static CourseEntity ToCourseFromCreateCourseDto(this CreateCourseDto courseDto)
    {
        return new CourseEntity
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Duration = courseDto.Duration,
            Price = courseDto.Price,
            ImagePath = courseDto.ImagePath
        };
    }

    public static CourseEntity ToCourseFromUpdateCourseDto(this UpdateCourseDto courseDto)
    {
        return new CourseEntity
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Duration = courseDto.Duration,
            Price = courseDto.Price,
            ImagePath = courseDto.ImagePath
        };
    }


    public static CourseDto ToCourseDto(this CourseEntity course)
    {
        return new CourseDto(
            course.Id,
            course.Title,
            course.Duration,
            course.Description,
            course.Price,
            course.ImagePath,
            course.CreatedTime,
            course.UpdatedTime
        );
    }
}

