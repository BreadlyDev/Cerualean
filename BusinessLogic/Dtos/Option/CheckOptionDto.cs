namespace BusinessLogic.Dtos.Option;

public record CheckOptionDto(
    int Id,
    string Text,
    bool IsCorrect,
    int QuestionId
);

