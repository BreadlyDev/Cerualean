using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class TestRepository(AppDbContext context) : ITestRepository
{
    public async Task AddAsync(TestEntity test, CancellationToken cancellationToken = default)
    {
        await context.Tests.AddAsync(test, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context
            .Tests.Where(t => t.Id == id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<TestEntity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Tests.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<TestEntity>> GetListByPageAndLessonAsync(
        int lessonId,
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Tests.AsNoTracking()
            .Where(t => t.LessonId == lessonId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<TestEntity>> GetListByPageAsync(
        int page,
        int pageSize,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Tests.AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TestEntity?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Tests.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Title == title, cancellationToken: cancellationToken);
    }

    public async Task UpdateByIdAsync(
        int id,
        TestEntity newTest,
        CancellationToken cancellationToken = default
    )
    {
        await context
            .Tests.Where(t => t.Id == id)
            .ExecuteUpdateAsync(
                t =>
                    t.SetProperty(t => t.LessonId, newTest.LessonId)
                        .SetProperty(t => t.Title, newTest.Title)
                        .SetProperty(t => t.Duration, newTest.Duration),
                cancellationToken: cancellationToken
            );
    }
}
