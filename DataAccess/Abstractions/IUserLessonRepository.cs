
using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IUserLessonRepository
{
	// CRUD
	Task AddAsync(UserLessonEntity userLesson, CancellationToken cancellationToken = default);
	Task<ICollection<UserLessonEntity>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserLessonEntity>> GetListByLessonIdAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<UserLessonEntity?> GetByUserAndTestId(int userId, int testId, CancellationToken cancellationToken = default);

	// Logic
	Task<bool> CanUserAccessLessonAsync(int userId, int lessonId);
}
