using BusinessLogic.Dtos.Test;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

internal class TestService(ITestRepository testRepository, IQuestionService questionService)
    : ITestService
{
    public async Task AddAsync(CreateTestDto test, CancellationToken cancellationToken = default)
    {
        await testRepository.AddAsync(test.ToTestFromCreateTestDto(), cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await testRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<TestDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var test = await testRepository.GetByIdAsync(id, cancellationToken);

        if (test == null)
        {
            return null;
        }

        return test.ToTestDto();
    }

    public async Task<ICollection<TestDto>> GetListByPageAndLessonAsync(
        int lessonId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var testList = await testRepository.GetListByPageAndLessonAsync(
            lessonId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var testDtoList = testList.Select(t => t.ToTestDto()).ToList();
        return testDtoList;
    }

    public async Task<ICollection<TestDto>> GetListByPageAsync(
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var testList = await testRepository.GetListByPageAsync(
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var testDtoList = testList.Select(t => t.ToTestDto()).ToList();
        return testDtoList;
    }

    public async Task<TestDto?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        var test = await testRepository.GetByTitleAsync(title, cancellationToken);
        return test!.ToTestDto();
    }

    public async Task UpdateByIdAsync(
        int id,
        UpdateTestDto newTest,
        CancellationToken cancellationToken = default
    )
    {
        await testRepository.UpdateByIdAsync(
            id,
            newTest.ToTestFromUpdateTestDto(),
            cancellationToken
        );
    }

    public async Task<RichTestDto?> GetWithQuestionsByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var test = await testRepository.GetByIdAsync(id, cancellationToken);

        if (test == null)
        {
            return null;
        }

        var questions = await questionService.GetListWithOptionsByTestAsync(
            test.Id,
            cancellationToken
        );
        var testDto = test.ToRichTestDto(questions);

        return testDto;
    }

    public async Task<ICollection<RichTestDto>> GetListWithQuestionsByPageAndLessonAsync(
        int lessonId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var testList = await testRepository.GetListByPageAndLessonAsync(
            lessonId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );

        var testDtoList = new List<RichTestDto>();

        foreach (var test in testList)
        {
            var questions = await questionService.GetListWithOptionsByTestAsync(
                test.Id,
                cancellationToken
            );
            var testDto = test.ToRichTestDto(questions);
            testDtoList.Add(testDto);
        }

        return testDtoList;
    }
}
