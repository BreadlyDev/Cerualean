using BusinessLogic.Dtos.Practice;
using BusinessLogic.Dtos.Test;
using BusinessLogic.Dtos.Theorie;
using DataAccess;

namespace BusinessLogic.Dtos.Lesson;

public record RichLessonDto(
    int Id,
    string Title,
    TimeSpan? Duration,
    string? Description,
    string? ImagePath,
    Level Level,
    DateTime? UpdatedTime,
    DateTime CreatedTime,
    int? CourseId,
    int? PreviousLessonId,
    int? NextLessonId,
    ICollection<RichTestDto> Tests,
    ICollection<PracticeDto> Practices,
    ICollection<TheorieDto> Theories
);
