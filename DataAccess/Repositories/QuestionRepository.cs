using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class QuestionRepository(AppDbContext context) : IQuestionRepository
{
    public async Task AddAsync(QuestionEntity question, CancellationToken cancellationToken = default)
    {
        await context.Questions.AddAsync(question, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context.Questions.Where(q => q.Id == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<QuestionEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Questions.AsNoTracking()
            .FirstOrDefaultAsync(q => q.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<QuestionEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await context.Questions.AsNoTracking()
            .FirstOrDefaultAsync(o => o.Text == title, cancellationToken: cancellationToken);
    }

    // public async Task<ICollection<QuestionEntity>> GetByPageAndTestAsync(int testId, int page, int pageSize, CancellationToken cancellationToken = default)
    // {
    //     return await context.Questions.AsNoTracking()
    //         .Where(q => q.TestId == testId)
    //         .Skip((page - 1) * pageSize)
    //         .Take(pageSize)
    //         .ToListAsync();
    // }

    public async Task<ICollection<QuestionEntity>> GetListByTestAsync(int testId, CancellationToken cancellationToken = default)
    {
        return await context.Questions.AsNoTracking()
            .Where(q => q.TestId == testId)
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task UpdateByIdAsync(int id, QuestionEntity newQuestion, CancellationToken cancellationToken = default)
    {
        await context.Questions.Where(q => q.Id == id)
            .ExecuteUpdateAsync(q => q.SetProperty(q => q.TestId, newQuestion.TestId)
            .SetProperty(q => q.ManyRightOptions, newQuestion.ManyRightOptions)
            .SetProperty(q => q.Text, newQuestion.Text), cancellationToken: cancellationToken);
    }
}

