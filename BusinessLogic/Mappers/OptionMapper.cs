using BusinessLogic.Dtos.Option;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class OptionMapper
{
    public static OptionEntity ToOptionFromCreateOptionDto(this CreateOptionDto optionDto)
    {
        return new OptionEntity
        {
            Text = optionDto.Text,
            IsCorrect = optionDto.IsCorrect,
            QuestionId = optionDto.QuestionId
        };
    }

    public static OptionEntity ToOptionFromUpdateOptionDto(this UpdateOptionDto optionDto)
    {
        return new OptionEntity
        {
            Text = optionDto.Text,
            IsCorrect = optionDto.IsCorrect,
            QuestionId = optionDto.QuestionId
        };
    }

    public static OptionDto ToOptionDto(this OptionEntity option)
    {
        return new OptionDto(
            option.Id,
            option.Text,
            option.QuestionId
        );
    }

    public static CheckOptionDto ToCheckOptionDto(this OptionEntity option)
    {
        return new CheckOptionDto(
            option.Id,
            option.Text,
            option.IsCorrect,
            option.QuestionId
        );
    }
}

