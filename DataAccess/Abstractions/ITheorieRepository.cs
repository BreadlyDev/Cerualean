using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface ITheorieRepository
{
    Task AddAsync(TheorieEntity theorie, CancellationToken cancellationToken = default);
    Task<TheorieEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TheorieEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<TheorieEntity>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<TheorieEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, TheorieEntity newTheorie, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

