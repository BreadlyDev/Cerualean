using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserTest;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

public class UserQuestionService(IUserQuestionRepository userQuestionRepository)
	: IUserQuestionService
{
	public async Task AddAsync(
		CreateUserQuestionDto userQuestion,
		CancellationToken cancellationToken = default
	)
	{
		await userQuestionRepository.AddAsync(
			userQuestion.ToQuestionFromCreateQuestionDto(),
			cancellationToken
		);
	}

	public async Task<UserQuestionDto?> GetByUserTestAndQuestionIdAsync(
		int userTestId,
		int questionId,
		CancellationToken cancellationToken = default
	)
	{
		var userQuestion = await userQuestionRepository.GetByUserTestAndQuestionId(
			userTestId,
			questionId,
			cancellationToken
		);

		if (userQuestion == null)
		{
			return null;
		}

		return userQuestion.ToUserQuestionDto();
	}

	public async Task<ICollection<UserQuestionDto>> GetListByQuestionIdAsync(
		int questionId,
		int? page,
		int? pageSize,
		CancellationToken cancellationToken = default
	)
	{
		var userQuestionList = await userQuestionRepository.GetListByQuestionIdAsync(
			questionId,
			page: page ?? PaginationDefaults.DefaultPage,
			pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
			cancellationToken
		);
		var userQuestionDtoList = userQuestionList.Select(uq => uq.ToUserQuestionDto()).ToList();
		return userQuestionDtoList;
	}

	public async Task<ICollection<UserQuestionDto>> GetListByUserTestIdAsync(
		int userTestId,
		int? page,
		int? pageSize,
		CancellationToken cancellationToken = default
	)
	{
		var userQuestionList = await userQuestionRepository.GetListByUserTestIdAsync(
			userTestId,
			page: page ?? PaginationDefaults.DefaultPage,
			pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
			cancellationToken
		);
		var userQuestionDtoList = userQuestionList.Select(ul => ul.ToUserQuestionDto()).ToList();
		return userQuestionDtoList;
	}
}
