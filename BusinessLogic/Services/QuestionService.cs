using BusinessLogic.Dtos.Question;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;

namespace BusinessLogic.Services;

internal class QuestionService(IQuestionRepository questionRepository, IOptionService optionService)
    : IQuestionService
{
    public async Task AddAsync(
        CreateQuestionDto question,
        CancellationToken cancellationToken = default
    )
    {
        await questionRepository.AddAsync(
            question.ToQuestionFromCreateQuestionDto(),
            cancellationToken
        );
    }

    public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        await questionRepository.DeleteByIdAsync(id, cancellationToken);
    }

    public async Task<QuestionDto?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var question = await questionRepository.GetByIdAsync(id, cancellationToken);

        if (question == null)
        {
            return null;
        }

        return question!.ToQuestionDto();
    }

    public async Task<QuestionDto?> GetByTitleAsync(
        string title,
        CancellationToken cancellationToken = default
    )
    {
        var question = await questionRepository.GetByTitleAsync(title, cancellationToken);

        if (question == null)
        {
            return null;
        }

        return question.ToQuestionDto();
    }

    public async Task<ICollection<QuestionDto>> GetListByTestAsync(
        int testId,
        CancellationToken cancellationToken = default
    )
    {
        var questionList = await questionRepository.GetListByTestAsync(testId, cancellationToken);
        var questionDtoList = questionList.Select(q => q.ToQuestionDto()).ToList();
        return questionDtoList;
    }

    public async Task<ICollection<RichQuestionDto>> GetListWithOptionsByTestAsync(
        int testId,
        CancellationToken cancellationToken = default
    )
    {
        var questionList = await questionRepository.GetListByTestAsync(testId, cancellationToken);

        var questionDtoList = new List<RichQuestionDto>();

        foreach (var question in questionList)
        {
            var options = await optionService.GetListByQuestionAsync(
                question.Id,
                cancellationToken
            );
            var optionsDto = options.OrderBy(_ => Guid.NewGuid()).ToList();
            var questionDto = question.ToRichQuestionDto(optionsDto);
            questionDtoList.Add(questionDto);
        }

        return questionDtoList;
    }

    public async Task<RichQuestionDto?> GetWithOptionsByIdAsync(
        int id,
        CancellationToken cancellationToken = default
    )
    {
        var question = await questionRepository.GetByIdAsync(id, cancellationToken);

        if (question == null)
        {
            return null;
        }

        var options = await optionService.GetListByQuestionAsync(question.Id, cancellationToken);
        var optionsDto = options.OrderBy(_ => Guid.NewGuid()).ToList();
        var questionDto = question.ToRichQuestionDto(optionsDto);

        return questionDto;
    }

    public async Task UpdateByIdAsync(
        int id,
        UpdateQuestionDto newQuestion,
        CancellationToken cancellationToken = default
    )
    {
        await questionRepository.UpdateByIdAsync(
            id,
            newQuestion.ToQuestionFromUpdateQuestionDto(),
            cancellationToken
        );
    }
}
