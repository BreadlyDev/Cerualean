namespace DataAccess.Entities;

public class TestEntity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public TimeSpan Duration { get; set; }
	public Level Level { get; set; }

	public int LessonId { get; set; }
	public LessonEntity? Lesson { get; set; }

	public ICollection<QuestionEntity> Questions { get; set; } = [];
}

