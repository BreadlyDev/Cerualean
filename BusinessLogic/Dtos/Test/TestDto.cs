using DataAccess;

namespace BusinessLogic.Dtos.Test;

public record TestDto(
	int Id,
	string Title,
	TimeSpan Duration,
	Level Level,
	int LessonId
);
