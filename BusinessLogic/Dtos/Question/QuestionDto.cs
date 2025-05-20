namespace BusinessLogic.Dtos.Question;

public record QuestionDto(
    int Id,
    string Text,
    bool ManyRightOptions,
    int TestId
);

