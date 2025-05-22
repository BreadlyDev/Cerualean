namespace BusinessLogic.Dtos.Theorie;

public record UpdateTheorieDto(
    string Title,
    string? SubTitle,
    string Content,
    string Format,
    int LessonId
);

