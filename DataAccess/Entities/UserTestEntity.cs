namespace DataAccess.Entities;


public class UserTestEntity
{
	public int UserId { get; set; }
	public UserEntity User { get; set; }

	public int TestId { get; set; }
	public TestEntity Test { get; set; }

	public DateTime StartedAt { get; set; }
	public DateTime? CompletedAt { get; set; }
	public TimeSpan? ElapsedTime { get; set; }

	public int? Result { get; set; }

	public ICollection<UserQuestionEntity> Questions { get; set; } = [];
}


