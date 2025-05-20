using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface ICourseRepository
{
    Task AddAsync(CourseEntity course, CancellationToken cancellationToken = default);
    Task<CourseEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CourseEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<CourseEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, CourseEntity newCourse, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

