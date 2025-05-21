using BusinessLogic.Dtos.Practice;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

internal class PracticeService(IPracticeRepository practiceRepository) : IPracticeService
{
    public async Task AddAsync(
        CreatePracticeDto practice,
        CancellationToken cancellationToken = default
    )
    {
        await practiceRepository.AddAsync(
            practice.ToPracticeFromCreatePracticeDto(),
            cancellationToken
        );
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await practiceRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<PracticeDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var practice = await practiceRepository.GetByIdAsync(id, cancellationToken);

        if (practice == null)
        {
            return null;
        }

        return practice.ToPracticeDto();
    }

    public async Task<PracticeDto?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        var practice = await practiceRepository.GetByTitleAsync(title, cancellationToken);

        if (practice == null)
        {
            return null;
        }

        return practice.ToPracticeDto();
    }

    public async Task<ICollection<PracticeDto>> GetListByPageAndLessonAsync(
        int lessonId,
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var practiceList = await practiceRepository.GetListByPageAndLessonAsync(
            lessonId,
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var practiceDtoList = practiceList.Select(p => p.ToPracticeDto()).ToList();
        return practiceDtoList;
    }

    public async Task<ICollection<PracticeDto>> GetListByPageAsync(
        int? page,
        int? pageSize,
        CancellationToken cancellationToken = default
    )
    {
        var practiceList = await practiceRepository.GetListByPageAsync(
            page: page ?? PaginationDefaults.DefaultPage,
            pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
            cancellationToken
        );
        var practiceDtoList = practiceList.Select(p => p.ToPracticeDto()).ToList();
        return practiceDtoList;
    }

    public async Task UpdateByIdAsync(
        int id,
        UpdatePracticeDto newPractice,
        CancellationToken cancellationToken = default
    )
    {
        await practiceRepository.UpdateByIdAsync(
            id,
            newPractice.ToPracticeFromUpdatePracticeDto(),
            cancellationToken
        );
    }
}
