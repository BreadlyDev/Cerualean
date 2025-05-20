using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IUserTestRepository
{
	// CRUD
	Task AddAsync(UserTestEntity userTest, CancellationToken cancellationToken = default);
	Task<ICollection<UserTestEntity>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserTestEntity>> GetListByTestIdAsync(int testId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<UserTestEntity?> GetByUserAndTestId(int userId, int testId, CancellationToken cancellationToken = default);

	// Logic
	Task StartTestAsync(int userId, int testId, CancellationToken cancellationToken = default);
	Task<UserTestEntity> CompleteTestAsync(int userId, int testId, CancellationToken cancellationToken = default);
	Task<bool> HasUserPassedTestAsync(int userId, int testId, CancellationToken cancellationToken = default);
	Task<TimeSpan?> GetElapsedTimeAsync(int userId, int testId, CancellationToken cancellationToken = default);

	/// <summary>
	/// Проверяет, не истекло ли время теста, и при необходимости завершает его.
	/// </summary>
	Task<UserTestEntity> GetOrCompleteIfExpiredAsync(int userId, int testId, CancellationToken cancellationToken = default);
	// Task UpdateByUserAndTestIdAsync(int userId, int testId, UserTestEntity newUserTest, CancellationToken cancellationToken = default);
	// Task DeleteByUserAndTestIdAsync(int userId, int testId, CancellationToken cancellationToken = default);
}

