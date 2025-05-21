using BusinessLogic.Dtos.UserLesson;

namespace BusinessLogic.Abstractions;

public interface IUserLessonService
{
	Task AddAsync(CreateUserLessonDto userLesson, CancellationToken cancellationToken = default);
	Task<ICollection<UserLessonDto>> GetListByUserIdAsync(int userId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserLessonDto>> GetListByLessonIdAsync(int lessonId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<UserLessonDto?> GetByUserAndLessonIdAsync(int userId, int lessonId, CancellationToken cancellationToken = default);

	// Logic
	Task<bool> CanUserAccessLessonAsync(int userId, int lessonId);
}
