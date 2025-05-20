using BusinessLogic.Dtos.UserTest;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserTestMapper
{
	public static UserTestEntity ToUserTestFromCreateTestDto(this CreateUserTestDto userTestDto)
	{
		return new UserTestEntity
		{
			UserId = userTestDto.UserId,
			TestId = userTestDto.TestId
		};
	}

	public static UserTestEntity ToUserTestFromUpdateTestDto(this UpdateUserTestDto userTestDto)
	{
		return new UserTestEntity
		{
			UserId = userTestDto.UserId,
			TestId = userTestDto.TestId
		};
	}

	public static UserTestDto ToUserTestDto(this UserTestEntity userTest)
	{
		return new UserTestDto(
			userTest.UserId,
			userTest.TestId,
			userTest.StartedAt,
			userTest.CompletedAt,
			userTest.ElapsedTime,
			userTest.Result
		);
	}
}
