namespace DataAccess.Entities;

public class UserLessonEntity
{
	public int LessonId { get; set; }
	public LessonEntity Lesson { get; set; }

	public int UserId { get; set; }
	public UserEntity User { get; set; }

	public DateTime CompletedAt { get; set; }
}

