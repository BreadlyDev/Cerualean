using BusinessLogic.Dtos.Course;

namespace DataAccess.Abstractions;

public interface ICourseService
{
    Task AddAsync(CreateCourseDto course, CancellationToken cancellationToken = default);
    Task<CourseDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<CourseDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<CourseDto>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdateCourseDto newCourse, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

