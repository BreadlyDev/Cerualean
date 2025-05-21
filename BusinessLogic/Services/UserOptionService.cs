using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserOption;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

public class UserOptionService(IUserOptionRepository userOptionRepository) : IUserOptionService
{
	public async Task AddAsync(
		CreateUserOptionDto userOption,
		CancellationToken cancellationToken = default
	)
	{
		await userOptionRepository.AddAsync(
			userOption.ToUserOptionFromCreateUserOptionDto(),
			cancellationToken
		);
	}

	public async Task<UserOptionDto?> GetByUserQuestionAndOptionIdAsync(
		int userQuestionId,
		int optionId,
		CancellationToken cancellationToken = default
	)
	{
		var userOption = await userOptionRepository.GetByUserQuestionAndOptionId(
			userQuestionId,
			optionId,
			cancellationToken
		);

		if (userOption == null)
		{
			return null;
		}

		return userOption.ToUserOptionDto();
	}

	public async Task<ICollection<UserOptionDto>> GetListByOptionIdAsync(
		int optionId,
		int? page,
		int? pageSize,
		CancellationToken cancellationToken = default
	)
	{
		var userOptionList = await userOptionRepository.GetListByOptionIdAsync(
			optionId,
			page: page ?? PaginationDefaults.DefaultPage,
			pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
			cancellationToken
		);
		var userOptionDtoList = userOptionList.Select(up => up.ToUserOptionDto()).ToList();
		return userOptionDtoList;
	}

	public async Task<ICollection<UserOptionDto>> GetListByUserQuestionIdAsync(
		int userQuestionId,
		int? page,
		int? pageSize,
		CancellationToken cancellationToken = default
	)
	{
		var userOptionList = await userOptionRepository.GetListByOptionIdAsync(
			userQuestionId,
			page: page ?? PaginationDefaults.DefaultPage,
			pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
			cancellationToken
		);
		var userOptionDtoList = userOptionList.Select(up => up.ToUserOptionDto()).ToList();
		return userOptionDtoList;
	}
}
