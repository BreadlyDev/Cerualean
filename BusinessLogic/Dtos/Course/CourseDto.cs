namespace BusinessLogic.Dtos.Course;

public record CourseDto(
   int Id,
   string Title,
   TimeSpan? Duration,
   string? Description,
   decimal? Price,
   string? ImagePath,
   DateTime CreatedTime,
   DateTime? UpdatedTime
);

