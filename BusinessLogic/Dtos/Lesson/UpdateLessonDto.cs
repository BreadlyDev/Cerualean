using DataAccess;

namespace BusinessLogic.Dtos.Lesson;

public record UpdateLessonDto(
    string Title,
    TimeSpan? Duration,
    string? Description,
    string? ImagePath,
    Level Level,
    int CourseId,
    int? PreviousLessonId,
    int? NextLessonId
);

