using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserLesson;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;

namespace BusinessLogic.Services;

internal class UserPracticeService(IUserPracticeRepository userPracticeRepository) : IUserPracticeService
{
	public async Task AddAsync(CreateUserPracticeDto userPractice, CancellationToken cancellationToken = default)
	{
		await userPracticeRepository.AddAsync(userPractice.ToPracticeFromCreatePracticeDto(), cancellationToken);
	}

	public async Task<UserPracticeDto?> GetByUserAndPracticeIdAsync(int userTestId, int practiceId, CancellationToken cancellationToken = default)
	{
		var userPractice = await userPracticeRepository.GetByUserPracticeAndPracticeId(userTestId, practiceId, cancellationToken);

		if (userPractice == null)
		{
			return null;
		}

		return userPractice.ToUserPracticeDto();
	}

	public async Task<ICollection<UserPracticeDto>> GetListByPracticeIdAsync(int practiceId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var userPracticeList = await userPracticeRepository.GetListByPracticeIdAsync(practiceId, page, pageSize, cancellationToken);
		var userPracticeDtoList = userPracticeList.Select(up => up.ToUserPracticeDto()).ToList();
		return userPracticeDtoList;
	}

	public async Task<ICollection<UserPracticeDto>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var userPracticeList = await userPracticeRepository.GetListByUserIdAsync(userId, page, pageSize, cancellationToken);
		var userPracticeDtoList = userPracticeList.Select(up => up.ToUserPracticeDto()).ToList();
		return userPracticeDtoList;
	}
}
