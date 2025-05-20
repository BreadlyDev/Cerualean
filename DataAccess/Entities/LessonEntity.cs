namespace DataAccess.Entities;

public class LessonEntity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string? Duration { get; set; }
	public string? Description { get; set; }
	public Level Level { get; set; }

	public string? ImagePath { get; set; }

	public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedTime { get; set; }

	public CourseEntity Course { get; set; }
	public int CourseId { get; set; }

	public LessonEntity? PreviousLesson { get; set; }
	public int PreviousLessonId { get; set; }

	public LessonEntity? NextLesson { get; set; }
	public int NextLessonId { get; set; }

	public ICollection<TestEntity> Tests { get; set; } = [];
	public ICollection<PracticeEntity> Practices { get; set; } = [];
	public ICollection<TheorieEntity> Theories { get; set; } = [];
}

