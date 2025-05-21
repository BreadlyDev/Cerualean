using BusinessLogic.Dtos.Course;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

internal class CourseService(ICourseRepository courseRepository) : ICourseService
{
    public async Task AddAsync(
        CreateCourseDto course,
        CancellationToken cancellationToken = default
    )
    {
        await courseRepository.AddAsync(course.ToCourseFromCreateCourseDto(), cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await courseRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<CourseDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var course = await courseRepository.GetByIdAsync(id, cancellationToken);

        if (course == null)
        {
            return null;
        }

        return course.ToCourseDto();
    }

    public async Task<CourseDto?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        var course = await courseRepository.GetByTitleAsync(title, cancellationToken);

        if (course == null)
        {
            return null;
        }

        return course.ToCourseDto();
    }

    public async Task<ICollection<CourseDto>> GetListByPageAsync(
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var courseList = await courseRepository.GetListByPageAsync(
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );

        var courseDtoList = courseList.Select(c => c.ToCourseDto()).ToList();

        return courseDtoList;
    }

    public async Task UpdateByIdAsync(
        int id,
        UpdateCourseDto newCourse,
        CancellationToken cancellationToken = default
    )
    {
        await courseRepository.UpdateByIdAsync(
            id,
            newCourse.ToCourseFromUpdateCourseDto(),
            cancellationToken
        );
    }
}
