namespace DataAccess.Entities;

// Not For Use
public class ProfileEntity
{
    public int Id { get; set; }
    public UserEntity Owner { get; set; }
    public int OwnerId { get; set; }
    public ICollection<LessonEntity> CompletedLessons { get; set; } = [];
    public ICollection<PracticeEntity> CompletedTasks { get; set; } = [];
    public ICollection<TestEntity> CompletedTests { get; set; } = [];
    public string FavoriteTopic { get; set; }
    public int Rating { get; set; }
    public DateTime LastTimeOnline { get; set; }
}

