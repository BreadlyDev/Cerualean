namespace BusinessLogic.Dtos.UserOption;

public record UpdateUserOptionDto(
	int UserQuestionId,
	int? OptionId,
	int CorrectOptionId,
	string? Explanation
);

