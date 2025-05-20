using DataAccess;

namespace BusinessLogic.Dtos.Practice;

public record CreatePracticeDto(
    string Title,
    string Condition,
    string? Hint,
    Level Level,
    TimeSpan? Duration,
    string Answer,
    int LessonId
);

