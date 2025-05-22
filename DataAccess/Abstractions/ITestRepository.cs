using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface ITestRepository
{
    Task AddAsync(TestEntity test, CancellationToken cancellationToken = default);
    Task<TestEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TestEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<TestEntity>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<TestEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, TestEntity newTest, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

