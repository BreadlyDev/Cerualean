namespace BusinessLogic.Dtos.UserLesson;

public record CreateUserPracticeDto(
    int PracticeId,
    int UserId,
    string Code,
    string? Output,
    string? Error,
    bool IsCorrect
);
