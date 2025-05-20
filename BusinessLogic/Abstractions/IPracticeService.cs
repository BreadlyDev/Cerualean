using BusinessLogic.Dtos.Practice;

namespace DataAccess.Abstractions;

public interface IPracticeService
{
    Task AddAsync(CreatePracticeDto practice, CancellationToken cancellationToken = default);
    Task<PracticeDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PracticeDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<PracticeDto>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<PracticeDto>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdatePracticeDto newPractice, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

