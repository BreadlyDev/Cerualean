namespace BusinessLogic.Dtos.Option;

public record UpdateOptionDto(
    string Text,
    bool IsCorrect,
    int QuestionId
);

