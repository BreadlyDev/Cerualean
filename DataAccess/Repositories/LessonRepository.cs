using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class LessonRepository(AppDbContext context) : ILessonRepository
{
    public async Task AddAsync(LessonEntity lesson, CancellationToken cancellationToken = default)
    {
        // lesson.CreatedTime = DateTime.UtcNow;
        await context.Lessons.AddAsync(lesson, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context.Lessons.Where(l => l.Id == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<LessonEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Lessons.AsNoTracking().FirstOrDefaultAsync(l => l.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<LessonEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await context.Lessons.AsNoTracking().FirstOrDefaultAsync(l => l.Title == title, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<LessonEntity>> GetListByPageAndCourseAsync(int courseId, int page, int pageSize, CancellationToken cancellationToken = default)
    {

        return await context.Lessons.AsNoTracking().Where(l => l.CourseId == courseId).Skip(
            (page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<LessonEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.Lessons.AsNoTracking().Skip(
            (page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken); ;
    }

    public async Task UpdateByIdAsync(int id, LessonEntity newLesson, CancellationToken cancellationToken = default)
    {
        await context.Lessons.Where(l => l.Id == id).ExecuteUpdateAsync(l => l.SetProperty(l => l.UpdatedTime, DateTime.UtcNow)
            .SetProperty(l => l.Title, newLesson.Title)
            .SetProperty(l => l.Description, newLesson.Description)
            .SetProperty(l => l.Duration, newLesson.Duration)
            .SetProperty(l => l.CourseId, newLesson.CourseId), cancellationToken: cancellationToken);
    }
}

