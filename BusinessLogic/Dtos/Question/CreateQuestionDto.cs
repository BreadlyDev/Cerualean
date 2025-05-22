namespace BusinessLogic.Dtos.Question;

public record CreateQuestionDto(
    string Text,
    bool ManyRightOptions,
    int TestId
);
