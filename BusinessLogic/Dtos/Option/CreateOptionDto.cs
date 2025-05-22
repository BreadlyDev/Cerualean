namespace BusinessLogic.Dtos.Option;

public record CreateOptionDto(
    string Text,
    bool IsCorrect,
    int QuestionId
);

