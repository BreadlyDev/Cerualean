using BusinessLogic.Dtos.UserLesson;
using BusinessLogic.Dtos.UserPractice;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserPracticeMapper
{
	public static UserPracticeEntity ToPracticeFromCreatePracticeDto(this CreateUserPracticeDto practiceDto)
	{
		return new UserPracticeEntity
		{
			UserId = practiceDto.UserId,
			PracticeId = practiceDto.PracticeId,
			Code = practiceDto.Code,
			Output = practiceDto.Output,
			Error = practiceDto.Error,
			IsCorrect = practiceDto.IsCorrect
		};
	}

	public static UserPracticeEntity ToPracticeFromCreatePracticeRequest(this CreateUserPracticeRequest practiceDto, int userId)
	{
		return new UserPracticeEntity
		{
			UserId = userId,
			PracticeId = practiceDto.PracticeId,
			Code = practiceDto.Code
		};
	}

	public static UserPracticeEntity ToPracticeFromUpdatePracticeDto(this UpdateUserPracticeDto practiceDto)
	{
		return new UserPracticeEntity
		{
			UserId = practiceDto.UserId,
			PracticeId = practiceDto.PracticeId,
			Code = practiceDto.Code,
			Output = practiceDto.Output,
			Error = practiceDto.Error,
			IsCorrect = practiceDto.IsCorrect
		};
	}

	public static UserPracticeDto ToUserPracticeDto(this UserPracticeEntity practice)
	{
		return new UserPracticeDto(
			practice.UserId,
			practice.PracticeId,
			practice.Code,
			practice.Output,
			practice.Error,
			practice.IsCorrect,
			practice.AttemptTime
		);
	}
}
