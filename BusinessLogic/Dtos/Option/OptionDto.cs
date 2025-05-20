namespace BusinessLogic.Dtos.Option;

public record OptionDto(
    int Id,
    string Text,
    bool IsCorrect,
    int QuestionId
);

