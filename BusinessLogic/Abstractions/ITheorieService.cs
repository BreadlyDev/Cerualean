using BusinessLogic.Dtos.Theorie;

namespace BusinessLogic.Abstractions;

public interface ITheorieService
{
    Task AddAsync(CreateTheorieDto theorie, CancellationToken cancellationToken = default);
    Task<TheorieDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TheorieDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<TheorieDto>> GetListByPageAndLessonAsync(int lessonId, int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<TheorieDto>> GetListByPageAsync(int? page, int? pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdateTheorieDto newTheorie, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

