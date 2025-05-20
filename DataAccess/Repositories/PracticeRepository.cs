using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class PracticeRepository(AppDbContext context) : IPracticeRepository
{
    public async Task AddAsync(PracticeEntity practice, CancellationToken cancellationToken = default)
    {
        await context.Practices.AddAsync(practice, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context.Practices.Where(p => p.Id == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<PracticeEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Practices.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<PracticeEntity>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.Practices.AsNoTracking()
            .Where(p => p.LessonId == lessonId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<PracticeEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.Practices.AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<PracticeEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await context.Practices.AsNoTracking()
            .FirstOrDefaultAsync(p => p.Title == title, cancellationToken: cancellationToken);
    }

    public async Task UpdateByIdAsync(int id, PracticeEntity newPractice, CancellationToken cancellationToken = default)
    {
        await context.Practices.Where(t => t.Id == id).
            ExecuteUpdateAsync(t => t.SetProperty(t => t.LessonId, newPractice.LessonId)
            .SetProperty(t => t.Title, newPractice.Title)
            .SetProperty(t => t.Duration, newPractice.Duration)
            .SetProperty(t => t.Condition, newPractice.Condition)
            .SetProperty(t => t.Hint, newPractice.Hint)
            .SetProperty(t => t.Answer, newPractice.Answer)
            .SetProperty(t => t.Level, newPractice.Level), cancellationToken: cancellationToken);
    }
}

