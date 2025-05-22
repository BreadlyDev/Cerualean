namespace DataAccess.Entities;

public class OptionEntity
{
    public int Id { get; set; }
    public string Text { get; set; }
    public bool IsCorrect { get; set; }
	
    public int QuestionId { get; set; }
    public QuestionEntity? Question { get; set; }
}

