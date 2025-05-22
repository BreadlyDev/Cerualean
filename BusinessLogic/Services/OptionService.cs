using BusinessLogic.Dtos.Option;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;

namespace BusinessLogic.Services;

internal class OptionService(IOptionRepository optionRepository) : IOptionService
{
    public async Task AddAsync(
        CreateOptionDto option,
        CancellationToken cancellationToken = default
    )
    {
        await optionRepository.AddAsync(option.ToOptionFromCreateOptionDto(), cancellationToken);
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await optionRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<OptionDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var option = await optionRepository.GetByIdAsync(id, cancellationToken);

        if (option == null)
        {
            return null;
        }

        return option.ToOptionDto();
    }

    public async Task<OptionDto?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        var option = await optionRepository.GetByTitleAsync(title, cancellationToken);

        if (option == null)
        {
            return null;
        }

        return option.ToOptionDto();
    }

    public async Task<ICollection<OptionDto>> GetListByQuestionAsync(
        int questionId,
        CancellationToken cancellationToken = default
    )
    {
        var optionList = await optionRepository.GetListByQuestionAsync(
            questionId,
            cancellationToken
        );
        var optionDtoList = optionList.Select(o => o.ToOptionDto()).ToList();
        return optionDtoList;
    }

    public async Task UpdateByIdAsync(
        int id,
        UpdateOptionDto newOption,
        CancellationToken cancellationToken = default
    )
    {
        await optionRepository.UpdateByIdAsync(
            id,
            newOption.ToOptionFromUpdateOptionDto(),
            cancellationToken
        );
    }
}
