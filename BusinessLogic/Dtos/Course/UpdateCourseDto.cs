namespace BusinessLogic.Dtos.Course;

public record UpdateCourseDto(
   string Title,
   TimeSpan? Duration,
   string? Description,
   decimal? Price,
   string? ImagePath
);

