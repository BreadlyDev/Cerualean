namespace DataAccess.Entities;

public class UserCourseEntity
{
	public int UserId { get; set; }
	public UserEntity User { get; set; }

	public int CourseId { get; set; }
	public CourseEntity Course { get; set; }
}

