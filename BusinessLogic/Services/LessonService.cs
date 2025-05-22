using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.Lesson;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using DataAccess.Repositories;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

internal class LessonService(
    ILessonRepository lessonRepository,
    ITheorieService theorieService,
    IPracticeService practiceService,
    ITestService testService
) : ILessonService
{
    public async Task AddAsync(
        CreateLessonDto lesson,
        CancellationToken cancellationToken = default
    )
    {
        await lessonRepository.AddAsync(lesson.ToLessonFromCreateLessonDto(), cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await lessonRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<LessonDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var lesson = await lessonRepository.GetByIdAsync(id, cancellationToken);

        if (lesson == null)
        {
            return null;
        }

        return lesson.ToLessonDto();
    }

    public async Task<LessonDto?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        var lesson = await lessonRepository.GetByTitleAsync(title, cancellationToken);

        if (lesson == null)
        {
            return null;
        }

        return lesson.ToLessonDto();
    }

    public async Task<ICollection<LessonDto>> GetListByPageAndCourseAsync(
        int courseId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var lessonList = await lessonRepository.GetListByPageAndCourseAsync(
            courseId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var lessonDtoList = lessonList.Select(l => l.ToLessonDto()).ToList();
        return lessonDtoList;
    }

    public async Task<ICollection<LessonDto>> GetListByPageAsync(
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var lessonList = await lessonRepository.GetListByPageAsync(
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var lessonDtoList = lessonList.Select(l => l.ToLessonDto()).ToList();
        return lessonDtoList;
    }

    public async Task<ICollection<RichLessonDto>> GetListWithFullInfoByPageAndCourseAsync(
        int courseId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var lessons = await lessonRepository.GetListByPageAndCourseAsync(
            courseId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );

        var lessonDtoList = new List<RichLessonDto>();

        foreach (var lesson in lessons)
        {
            var theories = await theorieService.GetListByPageAndLessonAsync(
                lesson.Id,
                page: page ?? PaginationDefaults.DefaultPage,
                pageSize,
                cancellationToken
            );
            var tests = await testService.GetListWithQuestionsByPageAndLessonAsync(
                lesson.Id,
                page: page ?? PaginationDefaults.DefaultPage,
                pageSize,
                cancellationToken
            );
            var practices = await practiceService.GetListByPageAndLessonAsync(
                lesson.Id,
                page: page ?? PaginationDefaults.DefaultPage,
                pageSize,
                cancellationToken
            );
            var lessonDto = lesson.ToRichLessonDto(tests, practices, theories);

            lessonDtoList.Add(lessonDto);
        }

        return lessonDtoList;
    }

    public Task<RichLessonDto?> GetWithFullInfoByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        throw new NotImplementedException();
    }

    public async Task UpdateByIdAsync(
        int id,
        UpdateLessonDto newLesson,
        CancellationToken cancellationToken = default
    )
    {
        await lessonRepository.UpdateByIdAsync(
            id,
            newLesson.ToLessonFromUpdateLessonDto(),
            cancellationToken
        );
    }
}
