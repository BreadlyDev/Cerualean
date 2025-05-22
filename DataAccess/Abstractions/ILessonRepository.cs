using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface ILessonRepository
{
    Task AddAsync(LessonEntity lesson, CancellationToken cancellationToken = default);
    Task<LessonEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<LessonEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<LessonEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<LessonEntity>> GetListByPageAndCourseAsync(int courseId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, LessonEntity newLesson, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

