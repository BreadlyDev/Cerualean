namespace BusinessLogic.Dtos.UserOption;

public record CreateUserOptionDto(
	int UserQuestionId,
	int? OptionId,
	int CorrectOptionId,
	string? Explanation
);

