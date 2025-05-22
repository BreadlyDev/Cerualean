using BusinessLogic.Dtos.Option;

namespace BusinessLogic.Dtos.Question;

public record RichQuestionDto(
    int Id,
    string Text,
    bool ManyRightOptions,
    int TestId,
    ICollection<OptionDto> Options
);

