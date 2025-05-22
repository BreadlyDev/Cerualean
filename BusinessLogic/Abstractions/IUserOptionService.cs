using BusinessLogic.Dtos.UserOption;

namespace BusinessLogic.Abstractions;

public interface IUserOptionService
{
	Task AddAsync(CreateUserOptionDto userOption, CancellationToken cancellationToken = default);
	Task<ICollection<UserOptionDto>> GetListByUserQuestionIdAsync(int userQuestionId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<ICollection<UserOptionDto>> GetListByOptionIdAsync(int optionId, int? page, int? pageSize, CancellationToken cancellationToken = default);
	Task<UserOptionDto?> GetByUserQuestionAndOptionIdAsync(int userQuestionId, int optionId, CancellationToken cancellationToken = default);
}
