using BusinessLogic.Dtos.Option;

namespace DataAccess.Abstractions;

public interface IOptionService
{
    Task AddAsync(CreateOptionDto option, CancellationToken cancellationToken = default);
    Task<OptionDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<OptionDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<OptionDto>> GetListByQuestionAsync(int questionId, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, UpdateOptionDto newOption, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

