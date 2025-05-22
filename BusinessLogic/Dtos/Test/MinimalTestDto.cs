using DataAccess;

namespace BusinessLogic.Dtos.Test;


public record MinimalTestDto(
	int Id,
	string Title,
	TimeSpan Duration,
	Level Level
);

