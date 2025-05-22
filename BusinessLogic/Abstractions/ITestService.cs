using BusinessLogic.Dtos.Test;

namespace DataAccess.Abstractions;

public interface ITestService
{
    Task AddAsync(CreateTestDto test, CancellationToken cancellationToken = default);
    Task<TestDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<RichTestDto?> GetWithQuestionsByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TestDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<TestDto>> GetListByPageAndLessonAsync(int lessonId, int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<RichTestDto>> GetListWithQuestionsByPageAndLessonAsync(int lessonId, int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<TestDto>> GetListByPageAsync(int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdateTestDto newTest, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

