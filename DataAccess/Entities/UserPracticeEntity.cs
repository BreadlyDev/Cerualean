namespace DataAccess.Entities;

public class UserPracticeEntity
{
    public int PracticeId { get; set; }
    public PracticeEntity Practice { get; set; }

    public int UserId { get; set; }
    public UserEntity User { get; set; }

    public string Code { get; set; }
    public string? Output { get; set; }
    public string? Error { get; set; }
    public bool IsCorrect { get; set; }

    public DateTime AttemptTime { get; set; } = DateTime.UtcNow;
}

