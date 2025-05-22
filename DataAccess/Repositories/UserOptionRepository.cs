using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class UserOptionRepository(AppDbContext context) : IUserOptionRepository
{
    public async Task AddAsync(UserOptionEntity userOption, CancellationToken cancellationToken = default)
    {
        await context.UserOptions.AddAsync(userOption, cancellationToken);
    }

    public async Task<UserOptionEntity?> GetByUserQuestionAndOptionId(int userQuestionId, int OptionId, CancellationToken cancellationToken = default)
    {
        return await context.UserOptions.AsNoTracking()
            .FirstOrDefaultAsync(uq => uq.UserQuestionId == userQuestionId
                && uq.OptionId == OptionId, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<UserOptionEntity>> GetListByOptionIdAsync(int OptionId, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.UserOptions.AsNoTracking()
            .Where(uq => uq.OptionId == OptionId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<ICollection<UserOptionEntity>> GetListByUserQuestionIdAsync(int userQuestionId, int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.UserOptions.AsNoTracking()
            .Where(uq => uq.UserQuestionId == userQuestionId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
    }
}

