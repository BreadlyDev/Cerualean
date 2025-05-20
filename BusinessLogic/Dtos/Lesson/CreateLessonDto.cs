using DataAccess;

namespace BusinessLogic.Dtos.Lesson;

public record CreateLessonDto(
    string Title,
    string? Duration,
    string? Description,
    string? ImagePath,
    Level Level,
    int CourseId,
    int PreviousLessonId,
    int NextLessonId
);

