namespace DataAccess.Entities;

public class UserQuestionEntity
{
    public int UserTestId { get; set; }
    public UserTestEntity UserTest { get; set; }

    public int QuestionId { get; set; }
    public QuestionEntity Question { get; set; }

    public ICollection<UserOptionEntity> SelectedOptions { get; set; } = [];
}

