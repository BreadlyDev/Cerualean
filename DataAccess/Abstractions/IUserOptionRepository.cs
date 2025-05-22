using DataAccess.Entities;

namespace DataAccess.Abstractions;

public interface IUserOptionRepository
{
    Task AddAsync(UserOptionEntity userOption, CancellationToken cancellationToken = default);
    Task<ICollection<UserOptionEntity>> GetListByUserQuestionIdAsync(int userQuestionId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<ICollection<UserOptionEntity>> GetListByOptionIdAsync(int optionId, int page, int pageSize, CancellationToken cancellationToken = default);
    Task<UserOptionEntity?> GetByUserQuestionAndOptionId(int userQuestionId, int optionId, CancellationToken cancellationToken = default);
}

