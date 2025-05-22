using BusinessLogic.Dtos.Practice;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class PracticeMapper
{
    public static PracticeEntity ToPracticeFromCreatePracticeDto(this CreatePracticeDto practiceDto)
    {
        return new PracticeEntity
        {
            Title = practiceDto.Title,
            Duration = practiceDto.Duration,
            Level = practiceDto.Level,
            Condition = practiceDto.Condition,
            LessonId = practiceDto.LessonId,
            Answer = practiceDto.Answer,
            Hint = practiceDto.Hint
        };

    }

    public static PracticeEntity ToPracticeFromUpdatePracticeDto(this UpdatePracticeDto practiceDto)
    {
        return new PracticeEntity
        {
            Title = practiceDto.Title,
            Duration = practiceDto.Duration,
            Level = practiceDto.Level,
            Condition = practiceDto.Condition,
            LessonId = practiceDto.LessonId,
            Answer = practiceDto.Answer,
            Hint = practiceDto.Hint
        };
    }

    public static PracticeDto ToPracticeDto(this PracticeEntity practice)
    {
        return new PracticeDto(
            practice.Id,
            practice.Title,
            practice.Condition,
            practice.Hint,
            practice.Level,
            practice.Duration,
            practice.Answer,
            practice.LessonId
        );
    }
}

