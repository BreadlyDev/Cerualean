using System.ComponentModel.DataAnnotations.Schema;
using Cerualean.Domain.CourseModule;

namespace Cerualean.Domain.Modules.Lessons
{
    [Table("lesson")]
    public class Lesson
    {
        [Column("id")] 
        public int Id { get; set; }
        [Column("title")] 
        public required string Title { get; set; }
        [Column("description")] 
        public string? Description { get; set; } = string.Empty;
        public Lesson? NextLesson { get; set; }
        [Column("next_lesson_id")] 
        public int? NextLessonId { get; set; }
        public Lesson? PreviousLesson { get; set; }
        [Column("previous_lesson_id")] 
        public int? PreviousLessonId { get; set; }
        public Course? Course { get; set; }
        [Column("course_id")] 
        public int? CourseId { get; set; }
        [Column("created_time")] 
        public DateTime CreatedTime { get; set; } = DateTime.Now.ToUniversalTime();
    }
}