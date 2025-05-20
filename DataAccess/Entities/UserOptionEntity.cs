namespace DataAccess.Entities;

public class UserOptionEntity
{
	public int UserQuestionId { get; set; }
	public UserQuestionEntity UserQuestion { get; set; }

	public int? OptionId { get; set; }
	public OptionEntity? Option { get; set; }

	public int CorrectOptionId { get; set; }
	public OptionEntity CorrectOption { get; set; }

	public string? Explanation { get; set; }
}

