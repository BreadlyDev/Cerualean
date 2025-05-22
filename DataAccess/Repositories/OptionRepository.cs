using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class OptionRepository(AppDbContext context) : IOptionRepository
{
    public async Task AddAsync(OptionEntity option, CancellationToken cancellationToken = default)
    {
        await context.Options.AddAsync(option, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context
            .Options.Where(o => o.Id == id)
            .ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<OptionEntity?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Options.AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<OptionEntity?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Options.AsNoTracking()
            .FirstOrDefaultAsync(o => o.Text == title, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<OptionEntity>> GetListByQuestionAsync(
        int questionId,
        CancellationToken cancellationToken = default
    )
    {
        return await context
            .Options.AsNoTracking()
            .Where(o => o.QuestionId == questionId)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task UpdateByIdAsync(
        int id,
        OptionEntity newOption,
        CancellationToken cancellationToken = default
    )
    {
        await context
            .Options.Where(o => o.Id == id)
            .ExecuteUpdateAsync(
                o =>
                    o.SetProperty(o => o.QuestionId, newOption.QuestionId)
                        .SetProperty(o => o.IsCorrect, newOption.IsCorrect)
                        .SetProperty(o => o.Text, newOption.Text),
                cancellationToken: cancellationToken
            );
    }
}
