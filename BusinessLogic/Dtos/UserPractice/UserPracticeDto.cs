namespace BusinessLogic.Dtos.UserLesson;

public record UserPracticeDto(
    int PracticeId,
    int UserId,
    string Code,
    string? Output,
    string? Error,
    bool IsCorrect,
    DateTime AttemptTime
);
