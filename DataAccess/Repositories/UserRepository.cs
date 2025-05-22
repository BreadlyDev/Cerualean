using DataAccess.Abstractions;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class UserRepository(AppDbContext context) : IUserRepository
{
	public async Task AddAsync(UserEntity user, CancellationToken cancellationToken = default)
	{
		await context.Users.AddAsync(user, cancellationToken);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		await context.Users.Where(u => u.Id == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
	}

	public async Task<UserEntity?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		return await context.Users.AsNoTracking()
			.Include(u => u.Role)
			.FirstOrDefaultAsync(u => u.Email == email, cancellationToken: cancellationToken);
	}

	public async Task<UserEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		return await context.Users.AsNoTracking()
			.Include(u => u.Role)
			.FirstOrDefaultAsync(u => u.Id == id, cancellationToken: cancellationToken);
	}

	public async Task<UserEntity?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default)
	{
		return await context.Users.AsNoTracking()
			.Include(u => u.Role)
			.FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken: cancellationToken);
	}

	public async Task<HashSet<Permission>> GetPermissionsAsync(int userId)
	{
		var role = await context.Users
			.AsNoTracking()
			.Include(u => u.Role)
			.ThenInclude(r => r.Permissions)
			.Where(u => u.Id == userId)
			.Select(u => u.Role)
			.ToArrayAsync();


		return role
			.SelectMany(r => r.Permissions)
			.Select(p => (Permission)p.Id)
			.ToHashSet();
	}

	// Needs To Be Updated
	public async Task UpdateByIdAsync(int id, UserEntity user, CancellationToken cancellationToken = default)
	{
		await context.Users.Where(u => u.Id == id)
			.ExecuteUpdateAsync(u => u.SetProperty(u => u.UserName, user.UserName), cancellationToken: cancellationToken);
	}
}

