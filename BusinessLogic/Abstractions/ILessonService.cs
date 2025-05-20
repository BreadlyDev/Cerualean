using BusinessLogic.Dtos.Lesson;

namespace DataAccess.Abstractions;

public interface ILessonService
{
    Task AddAsync(CreateLessonDto lesson, CancellationToken cancellationToken = default);
    Task<LessonDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<LessonDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<LessonDto>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<LessonDto>> GetListByPageAndCourseAsync(int courseId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdateLessonDto newLesson, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

