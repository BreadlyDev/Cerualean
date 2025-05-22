using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class UserPracticeRepository(AppDbContext context) : IUserPracticeRepository
{
	public async Task AddAsync(UserPracticeEntity userPractice, CancellationToken cancellationToken = default)
	{
		await context.UserPractices.AddAsync(userPractice, cancellationToken);
	}

	public async Task<UserPracticeEntity?> GetByUserPracticeAndPracticeId(int userId, int practiceId, CancellationToken cancellationToken = default)
	{
		return await context.UserPractices.AsNoTracking()
			.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.PracticeId == practiceId, cancellationToken: cancellationToken);
	}

	public async Task<ICollection<UserPracticeEntity>> GetListByPracticeIdAsync(int practiceId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserPractices.AsNoTracking()
			.Where(ut => ut.PracticeId == practiceId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<UserPracticeEntity>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserPractices.AsNoTracking()
			.Where(ut => ut.UserId == userId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}
}

