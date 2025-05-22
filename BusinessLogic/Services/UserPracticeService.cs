using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserLesson;
using BusinessLogic.Dtos.UserPractice;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

internal class UserPracticeService(
    IUserPracticeRepository userPracticeRepository,
    ICodeRunnerService codeRunnerService,
    IPracticeService practiceService
) : IUserPracticeService
{
    public async Task<ExecutionResult> CompileRunAndSaveAttemptAsync(
        CreateUserPracticeRequest userPracticeDto,
        int userId,
        CancellationToken cancellationToken = default
    )
    {
        var practice = await practiceService.GetByIdAsync(userPracticeDto.PracticeId);
        var executionResult = await codeRunnerService.CompileAndRunAsync(userPracticeDto.Code);

        var userPracticeToSave = new CreateUserPracticeDto(
            PracticeId: userPracticeDto.PracticeId,
            UserId: userId,
            Code: userPracticeDto.Code,
            Output: executionResult.Output,
            Error: executionResult.HasErrors
                ? string.Join("\n", (executionResult.Errors ?? []).ToArray())
                : null,
            IsCorrect: !executionResult.HasErrors
                && practice!.Answer.Trim() == executionResult.Output.Trim()
        );

        await userPracticeRepository.AddAsync(
            userPracticeToSave.ToPracticeFromCreatePracticeDto(),
            cancellationToken
        );

        return executionResult;
    }

    public async Task<UserPracticeDto?> GetByUserAndPracticeIdAsync(
        int userTestId,
        int practiceId,
        CancellationToken cancellationToken = default
    )
    {
        var userPractice = await userPracticeRepository.GetByUserPracticeAndPracticeId(
            userTestId,
            practiceId,
            cancellationToken
        );

        if (userPractice == null)
        {
            return null;
        }

        return userPractice.ToUserPracticeDto();
    }

    public async Task<ICollection<UserPracticeDto>> GetListByPracticeIdAsync(
        int practiceId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var userPracticeList = await userPracticeRepository.GetListByPracticeIdAsync(
            practiceId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var userPracticeDtoList = userPracticeList.Select(up => up.ToUserPracticeDto()).ToList();
        return userPracticeDtoList;
    }

    public async Task<ICollection<UserPracticeDto>> GetListByUserIdAsync(
        int userId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var userPracticeList = await userPracticeRepository.GetListByUserIdAsync(
            userId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var userPracticeDtoList = userPracticeList.Select(up => up.ToUserPracticeDto()).ToList();
        return userPracticeDtoList;
    }
}
