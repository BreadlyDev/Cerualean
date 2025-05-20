using DataAccess;

namespace BusinessLogic.Dtos.Lesson;

public record LessonDto(
    int Id,
    string Title,
    string? Duration,
    string? Description,
    string? ImagePath,
    Level Level,
    DateTime? UpdatedTime,
    DateTime CreatedTime,
    int CourseId,
    int PreviousLessonId,
    int NextLessonId
);
