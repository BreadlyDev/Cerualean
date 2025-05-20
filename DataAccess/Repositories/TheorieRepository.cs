using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class TheorieRepository(AppDbContext context) : ITheorieRepository
{
    public async Task AddAsync(TheorieEntity theorie, CancellationToken cancellationToken = default)
    {
        await context.Theories.AddAsync(theorie, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context.Theories.Where(t => t.Id == id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<TheorieEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Theories.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<TheorieEntity>> GetListByPageAndLessonAsync(int lessonId, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.Theories.AsNoTracking()
            .Where(t => t.LessonId == lessonId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<TheorieEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.Theories.AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TheorieEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await context.Theories.AsNoTracking()
            .FirstOrDefaultAsync(t => t.Title == title, cancellationToken: cancellationToken);
    }

    public async Task UpdateByIdAsync(int id, TheorieEntity newTheorie, CancellationToken cancellationToken = default)
    {
        await context.Theories.Where(t => t.Id == id)
            .ExecuteUpdateAsync(t => t.SetProperty(t => t.LessonId, newTheorie.LessonId)
            .SetProperty(t => t.Title, newTheorie.Title)
            .SetProperty(t => t.SubTitle, newTheorie.SubTitle)
            .SetProperty(t => t.Format, newTheorie.Format)
            .SetProperty(t => t.Content, newTheorie.Content), cancellationToken: cancellationToken);
    }
}

