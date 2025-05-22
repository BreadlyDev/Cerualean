namespace BusinessLogic.Dtos.Question;

public record MinimalQuestionDto(
    int Id,
    string Text,
    bool ManyRightOptions
);

