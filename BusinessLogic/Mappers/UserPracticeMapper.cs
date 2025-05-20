using BusinessLogic.Dtos.UserLesson;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserPracticeMapper
{
	public static UserPracticeEntity ToPracticeFromCreatePracticeDto(this CreateUserPracticeDto practiceDto)
	{
		return new UserPracticeEntity
		{
			UserId = practiceDto.UserId,
			PracticeId = practiceDto.PracticeId
		};
	}

	public static UserPracticeEntity ToPracticeFromUpdatePracticeDto(this UpdateUserPracticeDto practiceDto)
	{
		return new UserPracticeEntity
		{
			UserId = practiceDto.UserId,
			PracticeId = practiceDto.PracticeId
		};
	}

	public static UserPracticeDto ToUserPracticeDto(this UserPracticeEntity practice)
	{
		return new UserPracticeDto(
			practice.UserId,
			practice.PracticeId
		);
	}
}
