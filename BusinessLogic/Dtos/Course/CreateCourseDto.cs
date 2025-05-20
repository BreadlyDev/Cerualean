namespace BusinessLogic.Dtos.Course;

public record CreateCourseDto(
   string Title,
   string? Duration,
   string? Description,
   decimal? Price,
   string? ImagePath
);

