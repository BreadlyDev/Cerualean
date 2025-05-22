using DataAccess;

namespace BusinessLogic.Dtos.Test;

public record CreateTestDto(
	string Title,
	TimeSpan Duration,
	Level Level,
	int LessonId
);