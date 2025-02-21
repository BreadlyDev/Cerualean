using System.ComponentModel.DataAnnotations.Schema;
using Cerualean.Domain.CourseModule;

namespace Cerualean.Domain.Modules.Lessons
{
    [Table("lesson")]
    public class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Lesson? NextLesson { get; set; }
        public int? NextLessonId { get; set; }
        public Lesson? PreviousLesson { get; set; }
        public int? PreviousLessonId { get; set; }
        public Course? Course { get; set; }
        public int? CourseId { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now.ToUniversalTime();
    }
}