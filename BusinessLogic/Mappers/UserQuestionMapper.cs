using BusinessLogic.Dtos.UserTest;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserQuestionMapper
{
	public static UserQuestionEntity ToQuestionFromCreateQuestionDto(this CreateUserQuestionDto userQuestionDto)
	{
		return new UserQuestionEntity
		{
			UserTestId = userQuestionDto.UserTestId,
			QuestionId = userQuestionDto.QuestionId
		};
	}

	public static UserQuestionEntity ToQuestionFromUpdateQuestionDto(this UpdateUserQuestionDto userQuestionDto)
	{
		return new UserQuestionEntity
		{
			UserTestId = userQuestionDto.UserTestId,
			QuestionId = userQuestionDto.QuestionId
		};
	}

	public static UserQuestionDto ToUserQuestionDto(this UserQuestionEntity userQuestion)
	{
		return new UserQuestionDto(
			userQuestion.UserTestId,
			userQuestion.QuestionId
		);
	}
}
