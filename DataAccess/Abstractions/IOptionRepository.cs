using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IOptionRepository
{
    Task AddAsync(OptionEntity option, CancellationToken cancellationToken = default);
    Task<OptionEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<OptionEntity?> GetByTitleAsync(string title, CancellationToken cancellationToken = default);
    Task<ICollection<OptionEntity>> GetListByQuestionAsync(int questionId, CancellationToken cancellationToken = default);
    Task UpdateByIdAsync(int id, OptionEntity newOption, CancellationToken cancellationToken = default);
    Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default);
}

