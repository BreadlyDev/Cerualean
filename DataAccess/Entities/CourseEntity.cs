namespace DataAccess.Entities;

public class CourseEntity
{
	public int Id { get; set; }
	public string Title { get; set; }
	public TimeSpan? Duration { get; set; }
	public string? Description { get; set; }
	public decimal? Price { get; set; }

	public string? ImagePath { get; set; }

	public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedTime { get; set; }

	public ICollection<LessonEntity> Lessons { get; set; } = [];
}

