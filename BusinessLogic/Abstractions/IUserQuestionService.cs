using BusinessLogic.Dtos.UserTest;

namespace BusinessLogic.Abstractions;

public interface IUserQuestionService
{
	Task AddAsync(CreateUserQuestionDto userQuestion, CancellationToken cancellationToken = default);
	Task<ICollection<UserQuestionDto>> GetListByUserTestIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserQuestionDto>> GetListByQuestionIdAsync(int questionId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<UserQuestionDto?> GetByUserTestAndQuestionIdAsync(int userTestId, int questionId, CancellationToken cancellationToken = default);
}

