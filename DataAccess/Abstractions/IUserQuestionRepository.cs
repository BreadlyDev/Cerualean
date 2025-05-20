using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IUserQuestionRepository
{
	Task AddAsync(UserQuestionEntity userQuestion, CancellationToken cancellationToken = default);
	Task<ICollection<UserQuestionEntity>> GetListByUserTestIdAsync(int userTestId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserQuestionEntity>> GetListByQuestionIdAsync(int questionId, int page, int pageSize, CancellationToken cancellationToken = default);
	Task<UserQuestionEntity?> GetByUserTestAndQuestionId(int userTestId, int questionId, CancellationToken cancellationToken = default);
}

