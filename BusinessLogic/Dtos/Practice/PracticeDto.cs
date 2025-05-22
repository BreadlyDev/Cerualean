using DataAccess;

namespace BusinessLogic.Dtos.Practice;

public record PracticeDto(
    int Id,
    string Title,
    string Condition,
    string? Hint,
    Level Level,
    TimeSpan? Duration,
    string Answer,
    int LessonId
);

