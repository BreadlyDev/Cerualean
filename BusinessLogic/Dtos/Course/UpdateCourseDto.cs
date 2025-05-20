namespace BusinessLogic.Dtos.Course;

public record UpdateCourseDto(
   string Title,
   string? Duration,
   string? Description,
   decimal? Price,
   string? ImagePath
);

