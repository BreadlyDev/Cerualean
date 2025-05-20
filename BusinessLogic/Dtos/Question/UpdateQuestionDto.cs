namespace BusinessLogic.Dtos.Question;

public record UpdateQuestionDto(
    string Text,
    bool ManyRightOptions,
    int TestId
);

