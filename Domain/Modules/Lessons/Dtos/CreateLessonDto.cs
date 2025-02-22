namespace Cerualean.Domain.Modules.Lessons.Dtos
{
    public class CreateLessonDto
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int? NextLessonId { get; set; }
        public int? PreviousLessonId { get; set; }
    }
}