using BusinessLogic.Dtos.Question;

namespace DataAccess.Abstractions;

public interface IQuestionService
{
    Task AddAsync(CreateQuestionDto question, CancellationToken cancellationToken = default);
    Task<QuestionDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<QuestionDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<QuestionDto>> GetListByTestAsync(int testId, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdateQuestionDto newQuestion, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

