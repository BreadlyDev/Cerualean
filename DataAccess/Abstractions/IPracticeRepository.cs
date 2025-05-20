using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IPracticeRepository
{
    Task AddAsync(PracticeEntity practice, CancellationToken cancellationToken = default);
    Task<PracticeEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PracticeEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<PracticeEntity>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<PracticeEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, PracticeEntity newPractice, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

