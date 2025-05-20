using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IQuestionRepository
{
    Task AddAsync(QuestionEntity question, CancellationToken cancellationToken = default);
    Task<QuestionEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<QuestionEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<QuestionEntity>> GetListByTestAsync(int testId, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, QuestionEntity newQuestion, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

