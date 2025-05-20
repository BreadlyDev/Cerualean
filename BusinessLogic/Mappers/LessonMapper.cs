using BusinessLogic.Dtos.Lesson;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class LessonMapper
{
    public static LessonEntity ToLessonFromCreateLessonDto(this CreateLessonDto lessonDto)
    {
        return new LessonEntity
        {
            Title = lessonDto.Title,
            Description = lessonDto.Description,
            Duration = lessonDto.Duration,
            ImagePath = lessonDto.ImagePath,
            Level = lessonDto.Level,
            CourseId = lessonDto.CourseId,
            PreviousLessonId = lessonDto.PreviousLessonId,
            NextLessonId = lessonDto.NextLessonId
        };
    }

    public static LessonEntity ToLessonFromUpdateLessonDto(this UpdateLessonDto lessonDto)
    {
        return new LessonEntity
        {
            Title = lessonDto.Title,
            Description = lessonDto.Description,
            Duration = lessonDto.Duration,
            ImagePath = lessonDto.ImagePath,
            Level = lessonDto.Level,
            CourseId = lessonDto.CourseId,
            PreviousLessonId = lessonDto.PreviousLessonId,
            NextLessonId = lessonDto.NextLessonId
        };
    }

    public static LessonDto ToLessonDto(this LessonEntity Lesson)
    {
        return new LessonDto(
            Lesson.Id,
            Lesson.Title,
            Lesson.Duration,
            Lesson.Description,
            Lesson.ImagePath,
            Lesson.Level,
            Lesson.UpdatedTime,
            Lesson.CreatedTime,
            Lesson.CourseId,
            Lesson.PreviousLessonId,
            Lesson.NextLessonId
        );
    }
}

