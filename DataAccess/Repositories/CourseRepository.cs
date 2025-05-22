using DataAccess.Abstractions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

internal class CourseRepository(AppDbContext context) : ICourseRepository
{
    public async Task AddAsync(CourseEntity course, CancellationToken cancellationToken = default)
    {
        // course.CreatedTime = DateTime.UtcNow;
        await context.Courses.AddAsync(course, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await context.Courses.Where(c => c.Id == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
    }

    public async Task<CourseEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<CourseEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
    {
        return await context.Courses.AsNoTracking().FirstOrDefaultAsync(c => c.Title == title, cancellationToken: cancellationToken);
    }

    public async Task<ICollection<CourseEntity>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
    {
        return await context.Courses.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task UpdateByIdAsync(int id, CourseEntity newCourse, CancellationToken cancellationToken = default)
    {
        await context.Courses.Where(c => c.Id == id).ExecuteUpdateAsync(c => c.SetProperty(c => c.UpdatedTime, DateTime.UtcNow)
            .SetProperty(c => c.Title, newCourse.Title)
            .SetProperty(c => c.Description, newCourse.Description)
            .SetProperty(c => c.ImagePath, newCourse.ImagePath)
            .SetProperty(c => c.Duration, newCourse.Duration), cancellationToken: cancellationToken);
    }
}

