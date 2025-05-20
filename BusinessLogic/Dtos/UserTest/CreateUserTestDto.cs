namespace BusinessLogic.Dtos.UserTest;

public record CreateUserTestDto(
	int UserId,
	int TestId,
	DateTime StartedAt,
	DateTime? CompletedAt,
	TimeSpan? ElapsedTime,
	int? Result
);

