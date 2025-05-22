namespace BusinessLogic.Dtos.UserLesson;

// Deprecated
public record UpdateUserPracticeDto(
	int PracticeId,
	int UserId,
	string Code,
	string? Output,
	string? Error,
	bool IsCorrect
);
