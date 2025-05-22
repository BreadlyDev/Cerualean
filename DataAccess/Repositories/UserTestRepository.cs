using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class UserTestRepository(AppDbContext context) : IUserTestRepository
{
	public async Task AddAsync(UserTestEntity userTest, CancellationToken cancellationToken = default)
	{
		await context.UserTests.AddAsync(userTest, cancellationToken);
	}

	public async Task<UserTestEntity?> GetByUserAndTestId(int userId, int testId, CancellationToken cancellationToken = default)
	{
		return await context.UserTests.AsNoTracking()
			.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId, cancellationToken: cancellationToken);
	}

	public async Task<ICollection<UserTestEntity>> GetListByTestIdAsync(int testId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserTests.AsNoTracking()
			.Where(ut => ut.TestId == testId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<UserTestEntity>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserTests.AsNoTracking()
			.Where(ut => ut.UserId == userId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}

	public async Task StartTestAsync(int userId, int testId, CancellationToken cancellationToken = default)
	{
		var existing = await context.UserTests.AsNoTracking()
			.FirstOrDefaultAsync(x => x.UserId == userId
				&& x.TestId == testId, cancellationToken: cancellationToken);

		if (existing != null)
			return;

		var userTest = new UserTestEntity
		{
			UserId = userId,
			TestId = testId,
			StartedAt = DateTime.UtcNow
		};

		context.UserTests.Add(userTest);
		await context.SaveChangesAsync(cancellationToken);
	}

	public async Task<UserTestEntity> CompleteTestAsync(int userId, int testId, CancellationToken cancellationToken = default)
	{
		var userTest = await context.UserTests
			.Include(ut => ut.Questions)
				.ThenInclude(q => q.SelectedOptions)
				.ThenInclude(o => o.Option)
			.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.TestId == testId, cancellationToken);

		if (userTest == null)
			throw new InvalidOperationException("Test not started.");

		int correctAnswers = userTest.Questions.Count(q =>
			q.SelectedOptions.All(opt => opt.OptionId == opt.CorrectOptionId)
			&& q.SelectedOptions.Count == 1
		);

		userTest.CompletedAt = DateTime.UtcNow;
		userTest.Result = correctAnswers;
		userTest.ElapsedTime = userTest.CompletedAt - userTest.StartedAt;

		await context.SaveChangesAsync(cancellationToken);

		return userTest;
	}

	public async Task<bool> HasUserPassedTestAsync(int userId, int testId, CancellationToken cancellationToken = default)
	{
		return await context.UserTests
			.AnyAsync(x => x.UserId == userId && x.TestId == testId && x.CompletedAt != null, cancellationToken: cancellationToken);
	}

	public async Task<TimeSpan?> GetElapsedTimeAsync(int userId, int testId, CancellationToken cancellationToken = default)
	{
		var userTest = await context.UserTests.AsNoTracking()
			.FirstOrDefaultAsync(x => x.UserId == userId && x.TestId == testId, cancellationToken: cancellationToken);

		return userTest?.ElapsedTime;
	}

	public async Task<UserTestEntity> GetOrCompleteIfExpiredAsync(int userId, int testId, CancellationToken cancellationToken = default)
	{
		var userTest = await context.UserTests
			.Include(ut => ut.Test)
			.FirstOrDefaultAsync(x => x.UserId == userId && x.TestId == testId, cancellationToken: cancellationToken);

		if (userTest == null)
			throw new InvalidOperationException("Test not started.");

		if (userTest.CompletedAt != null)
			return userTest;

		var now = DateTime.UtcNow;
		var timeLimit = userTest.Test.Duration;
		var elapsed = now - userTest.StartedAt;

		if (elapsed > timeLimit)
		{
			userTest.CompletedAt = now;
			userTest.ElapsedTime = elapsed;
			userTest.Result ??= 0;

			await context.SaveChangesAsync(cancellationToken);
		}

		return userTest;
	}
}

