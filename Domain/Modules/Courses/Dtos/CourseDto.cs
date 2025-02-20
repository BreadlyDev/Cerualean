namespace Cerualean.Domain.CourseModule.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string Duration { get; set; }
        public double Price { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}