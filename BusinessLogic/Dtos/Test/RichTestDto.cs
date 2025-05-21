using BusinessLogic.Dtos.Question;
using DataAccess;

namespace BusinessLogic.Dtos.Test;

public record RichTestDto(
    int Id,
    string Title,
    TimeSpan Duration,
    Level Level,
    int LessonId,
    ICollection<RichQuestionDto> Questions
);

