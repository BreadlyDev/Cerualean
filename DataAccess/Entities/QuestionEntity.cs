namespace DataAccess.Entities;

public class QuestionEntity
{
	public int Id { get; set; }
	public string Text { get; set; }
	public bool ManyRightOptions { get; set; } = false;

	public int TestId { get; set; }
	public TestEntity Test { get; set; }

	public ICollection<OptionEntity> Options { get; set; } = [];
}

