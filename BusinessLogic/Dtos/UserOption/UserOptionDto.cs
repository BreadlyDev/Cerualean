namespace BusinessLogic.Dtos.UserOption;

public record UserOptionDto(
	int UserQuestionId,
	int? OptionId,
	int CorrectOptionId,
	string? Explanation
);

