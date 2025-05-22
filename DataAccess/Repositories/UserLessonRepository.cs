using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class UserLessonRepository(AppDbContext context) : IUserLessonRepository
{
	public async Task AddAsync(UserLessonEntity userLesson, CancellationToken cancellationToken = default)
	{
		await context.UserLessons.AddAsync(userLesson, cancellationToken);
	}
	
	public async Task<UserLessonEntity?> GetByUserAndLessonId(int userId, int LessonId, CancellationToken cancellationToken = default)
	{
		return await context.UserLessons.AsNoTracking()
			.FirstOrDefaultAsync(ut => ut.UserId == userId && ut.LessonId == LessonId, cancellationToken: cancellationToken);
	}

	public Task<UserLessonEntity?> GetByUserAndTestId(int userId, int testId, CancellationToken cancellationToken = default)
	{
		throw new NotImplementedException();
	}

	public async Task<ICollection<UserLessonEntity>> GetListByLessonIdAsync(int LessonId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserLessons.AsNoTracking()
			.Where(ut => ut.LessonId == LessonId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}
	public async Task<ICollection<UserLessonEntity>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserLessons.AsNoTracking()
			.Where(ut => ut.UserId == userId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}

	public async Task<bool> CanUserAccessLessonAsync(int userId, int lessonId)
	{
		var lesson = await context.Lessons
			.AsNoTracking()
			.FirstOrDefaultAsync(l => l.Id == lessonId);

		if (lesson == null)
			throw new InvalidOperationException("Lesson not found.");

		if (lesson.PreviousLessonId == 0)
			return true;

		var passed = await context.UserLessons
			.AsNoTracking()
			.AnyAsync(ul =>
				ul.UserId == userId &&
				ul.LessonId == lesson.PreviousLessonId &&
				ul.CompletedAt != default);

		return passed;
	}
}

