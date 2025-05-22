using BusinessLogic.Dtos.Lesson;
using BusinessLogic.Dtos.Practice;
using BusinessLogic.Dtos.Test;
using BusinessLogic.Dtos.Theorie;
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

    public static LessonDto ToLessonDto(this LessonEntity lesson)
    {
        return new LessonDto(
            lesson.Id,
            lesson.Title,
            lesson.Duration,
            lesson.Description,
            lesson.ImagePath,
            lesson.Level,
            lesson.UpdatedTime,
            lesson.CreatedTime,
            lesson.CourseId,
            lesson.PreviousLessonId,
            lesson.NextLessonId
        );
    }

    public static RichLessonDto ToRichLessonDto(this LessonEntity lesson,
        ICollection<RichTestDto> tests,
        ICollection<PracticeDto> practices,
        ICollection<TheorieDto> theories)
    {
        return new RichLessonDto(
            lesson.Id,
            lesson.Title,
            lesson.Duration,
            lesson.Description,
            lesson.ImagePath,
            lesson.Level,
            lesson.UpdatedTime,
            lesson.CreatedTime,
            lesson.CourseId,
            lesson.PreviousLessonId,
            lesson.NextLessonId,
            tests,
            practices,
            theories
        );
    }
}

