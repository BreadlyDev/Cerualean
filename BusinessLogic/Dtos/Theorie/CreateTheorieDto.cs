namespace BusinessLogic.Dtos.Theorie;

public record CreateTheorieDto(
    string Title,
    string? SubTitle,
    string Content,
    string Format,
    int LessonId
);

