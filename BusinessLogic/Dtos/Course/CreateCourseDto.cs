namespace BusinessLogic.Dtos.Course;

public record CreateCourseDto(
   string Title,
   TimeSpan? Duration,
   string? Description,
   decimal? Price,
   string? ImagePath
);

