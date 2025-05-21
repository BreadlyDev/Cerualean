using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserLesson;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;
using Infrastructure.Pagination;

namespace BusinessLogic.Services;

internal class UserLessonService(IUserLessonRepository userLessonRepository) : IUserLessonService
{
	public async Task AddAsync(
		CreateUserLessonDto userLesson,
		CancellationToken cancellationToken = default
	)
	{
		await userLessonRepository.AddAsync(
			userLesson.ToUserLessonFromCreateUserLessonDto(),
			cancellationToken
		);
	}

	public async Task<bool> CanUserAccessLessonAsync(int userId, int lessonId)
	{
		return await userLessonRepository.CanUserAccessLessonAsync(userId, lessonId);
	}

	public async Task<UserLessonDto?> GetByUserAndLessonIdAsync(
		int userId,
		int testId,
		CancellationToken cancellationToken = default
	)
	{
		var userLesson = await userLessonRepository.GetByUserAndTestId(
			userId,
			testId,
			cancellationToken
		);

		if (userLesson == null)
		{
			return null;
		}

		return userLesson.ToUserLessonDto();
	}

	public async Task<ICollection<UserLessonDto>> GetListByLessonIdAsync(
		int lessonId,
		int? page,
		int? pageSize,
		CancellationToken cancellationToken = default
	)
	{
		var userLessonList = await userLessonRepository.GetListByLessonIdAsync(
			lessonId,
			page: page ?? PaginationDefaults.DefaultPage,
			pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
			cancellationToken
		);
		var userLessonDtoList = userLessonList.Select(ul => ul.ToUserLessonDto()).ToList();
		return userLessonDtoList;
	}

	public async Task<ICollection<UserLessonDto>> GetListByUserIdAsync(
		int userId,
		int? page,
		int? pageSize,
		CancellationToken cancellationToken = default
	)
	{
		var userLessonList = await userLessonRepository.GetListByLessonIdAsync(
			userId,
			page: page ?? PaginationDefaults.DefaultPage,
			pageSize: pageSize ?? PaginationDefaults.DefaultPageSize,
			cancellationToken
		);
		var userLessonDtoList = userLessonList.Select(ul => ul.ToUserLessonDto()).ToList();
		return userLessonDtoList;
	}
}
