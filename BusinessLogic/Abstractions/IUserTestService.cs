using BusinessLogic.Dtos.UserTest;

namespace BusinessLogic.Abstractions;

public interface IUserTestService
{
	// CRUD
	Task AddAsync(CreateUserTestRequest userTestRequest, int userId, CancellationToken cancellationToken = default);
	Task<ICollection<UserTestDto>> GetListByUserIdAsync(int userId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserTestDto>> GetListByTestIdAsync(int testId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<UserTestDto?> GetByUserAndTestIdAsync(int userId, int testId, CancellationToken cancellationToken = default);

	// Logic
	Task<UserTestDto> StartAsync(int userId, int testId, CancellationToken ct = default);
	Task<UserTestDto> CompleteAsync(int userId, int testId, CancellationToken ct = default);
	Task<bool> IsCompletedAsync(int userId, int testId, CancellationToken ct = default);
	Task<TimeSpan?> GetElapsedAsync(int userId, int testId, CancellationToken ct = default);
	// Task<QuestionDto?> GetQuestionAsync(int userId, int testId);
}

