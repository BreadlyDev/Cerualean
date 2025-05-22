using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IUserPracticeRepository
{
	Task AddAsync(UserPracticeEntity userPractice, CancellationToken cancellationToken = default);
	Task<ICollection<UserPracticeEntity>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserPracticeEntity>> GetListByPracticeIdAsync(int practiceId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<UserPracticeEntity?> GetByUserPracticeAndPracticeId(int userTestId, int practiceId, CancellationToken cancellationToken = default);
}
