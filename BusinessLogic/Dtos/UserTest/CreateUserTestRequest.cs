namespace BusinessLogic.Dtos.UserTest;

public record CreateUserTestRequest(
    int TestId,
    DateTime StartedAt,
    DateTime? CompletedAt,
    TimeSpan? ElapsedTime,
    int? Result
);
