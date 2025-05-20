namespace BusinessLogic.Dtos.UserTest;

public record UpdateUserTestDto(
	int UserId,
	int TestId,
	DateTime StartedAt,
	DateTime? CompletedAt,
	TimeSpan? ElapsedTime,
	int? Result
);

