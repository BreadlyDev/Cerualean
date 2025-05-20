namespace DataAccess.Entities;

public class UserPracticeEntity
{
    public int PracticeId { get; set; }
    public PracticeEntity Practice { get; set; }
	
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}

