namespace DataAccess.Entities;

public class PracticeEntity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Condition { get; set; }
	public string? Hint { get; set; }
	public Level Level { get; set; }
	public TimeSpan? Duration { get; set; }
	public string Answer { get; set; }

	public int LessonId { get; set; }
	public LessonEntity? Lesson { get; set; }
}

