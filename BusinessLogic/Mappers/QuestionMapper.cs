using BusinessLogic.Dtos.Question;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class QuestionMapper
{
    public static QuestionEntity ToQuestionFromCreateQuestionDto(this CreateQuestionDto questionDto)
    {
        return new QuestionEntity
        {
            Text = questionDto.Text,
            ManyRightOptions = questionDto.ManyRightOptions,
            TestId = questionDto.TestId
        };
    }

    public static QuestionEntity ToQuestionFromUpdateQuestionDto(this UpdateQuestionDto questionDto)
    {
        return new QuestionEntity
        {
            Text = questionDto.Text,
            ManyRightOptions = questionDto.ManyRightOptions,
            TestId = questionDto.TestId
        };
    }

    public static QuestionDto ToQuestionDto(this QuestionEntity question)
    {
        return new QuestionDto(
            question.Id,
            question.Text,
            question.ManyRightOptions,
            question.TestId
        );
    }
}

