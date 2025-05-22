using DataAccess;

namespace BusinessLogic.Dtos.Test;

public record UpdateTestDto(
	string Title,
	TimeSpan Duration,
	Level Level,
	int LessonId
);

