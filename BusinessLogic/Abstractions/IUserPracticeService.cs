using BusinessLogic.Dtos.UserLesson;
using BusinessLogic.Dtos.UserPractice;

namespace BusinessLogic.Abstractions;

public interface IUserPracticeService
{
	// Task AddAsync(CreateUserPracticeDto userPractice, CancellationToken cancellationToken = default);
	Task<ExecutionResult> CompileRunAndSaveAttemptAsync(CreateUserPracticeRequest userPracticeRequest, int userId, CancellationToken cancellationToken = default);
	Task<ICollection<UserPracticeDto>> GetListByUserIdAsync(int userId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserPracticeDto>> GetListByPracticeIdAsync(int practiceId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<UserPracticeDto?> GetByUserAndPracticeIdAsync(int userId, int practiceId, CancellationToken cancellationToken = default);
}
