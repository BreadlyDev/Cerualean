namespace DataAccess.Entities;

public class TheorieEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? SubTitle { get; set; }
    public string Content { get; set; }
    public string Format { get; set; }
	
    public int LessonId { get; set; }
    public LessonEntity Lesson { get; set; }
}

