using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class UserQuestionRepository(AppDbContext context) : IUserQuestionRepository
{
	public async Task AddAsync(UserQuestionEntity userQuestion, CancellationToken cancellationToken = default)
	{
		await context.UserQuestions.AddAsync(userQuestion, cancellationToken);
	}

	public async Task<UserQuestionEntity?> GetByUserTestAndQuestionId(int userTestId, int questionId, CancellationToken cancellationToken = default)
	{
		return await context.UserQuestions.AsNoTracking()
			.FirstOrDefaultAsync(uq => uq.UserTestId == userTestId
				&& uq.QuestionId == questionId, cancellationToken: cancellationToken);
	}

	public async Task<ICollection<UserQuestionEntity>> GetListByQuestionIdAsync(int questionId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserQuestions.AsNoTracking()
			.Where(uq => uq.QuestionId == questionId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}

	public async Task<ICollection<UserQuestionEntity>> GetListByUserTestIdAsync(int userTestId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		return await context.UserQuestions.AsNoTracking()
			.Where(uq => uq.UserTestId == userTestId)
			.Skip((page - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);
	}
}

