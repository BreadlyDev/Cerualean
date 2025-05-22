namespace BusinessLogic.Dtos.Theorie;

public record TheorieDto(
	int Id,
	string Title,
	string? SubTitle,
	string Content,
	string Format,
	int LessonId
);
