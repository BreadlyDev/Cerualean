using BusinessLogic.Dtos.UserOption;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserOptionMapper
{
	public static UserOptionEntity ToUserOptionFromCreateUserOptionDto(this CreateUserOptionDto optionDto)
	{
		return new UserOptionEntity
		{
			UserQuestionId = optionDto.UserQuestionId,
			OptionId = optionDto.OptionId,
			CorrectOptionId = optionDto.CorrectOptionId,
			Explanation = optionDto.Explanation
		};
	}

	public static UserOptionEntity ToUserOptionFromUpdateUserOptionDto(this UpdateUserOptionDto optionDto)
	{
		return new UserOptionEntity
		{
			UserQuestionId = optionDto.UserQuestionId,
			OptionId = optionDto.OptionId,
			CorrectOptionId = optionDto.CorrectOptionId,
			Explanation = optionDto.Explanation
		};
	}

	public static UserOptionDto ToUserOptionDto(this UserOptionEntity option)
	{
		return new UserOptionDto(
			option.UserQuestionId,
			option.OptionId,
			option.CorrectOptionId,
			option.Explanation
		);
	}
}
