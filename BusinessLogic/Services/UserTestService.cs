using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.Question;
using BusinessLogic.Dtos.UserTest;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;

namespace BusinessLogic.Services;

internal class UserTestService(IUserTestRepository userTestRepository) : IUserTestService
{
	public async Task AddAsync(CreateUserTestDto userTest, CancellationToken cancellationToken = default)
	{
		await userTestRepository.AddAsync(userTest.ToUserTestFromCreateTestDto(), cancellationToken);
	}

	public async Task<UserTestDto> CompleteTestAsync(int userId, int testId)
	{
		var userTest = await userTestRepository.CompleteTestAsync(userId, testId);
		return userTest.ToUserTestDto();
	}

	public async Task<UserTestDto?> GetByUserAndTestIdAsync(int userId, int testId, CancellationToken cancellationToken = default)
	{
		var userTest = await userTestRepository.GetByUserAndTestId(userId, testId, cancellationToken);

		if (userTest == null)
		{
			return null;
		}

		return userTest.ToUserTestDto();
	}

	public async Task<UserTestDto> StartAsync(int userId, int testId, CancellationToken ct = default)
	{
		await userTestRepository.StartTestAsync(userId, testId, ct);
		var userTest = await userTestRepository.GetOrCompleteIfExpiredAsync(userId, testId, ct);
		return userTest.ToUserTestDto();
	}

	public async Task<UserTestDto> CompleteAsync(int userId, int testId, CancellationToken ct = default)
	{
		var userTest = await userTestRepository.CompleteTestAsync(userId, testId, ct);
		return userTest.ToUserTestDto();
	}

	public async Task<bool> IsCompletedAsync(int userId, int testId, CancellationToken ct = default)
	{
		return await userTestRepository.HasUserPassedTestAsync(userId, testId, ct);
	}

	public async Task<TimeSpan?> GetElapsedAsync(int userId, int testId, CancellationToken ct = default)
	{
		return await userTestRepository.GetElapsedTimeAsync(userId, testId, ct);
	}

	public async Task<ICollection<UserTestDto>> GetListByUserIdAsync(int userId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var userTestList = await userTestRepository.GetListByUserIdAsync(userId, page, pageSize, cancellationToken);
		var userTestDtoList = userTestList.Select(ut => ut.ToUserTestDto()).ToList();

		return userTestDtoList;
	}

	public async Task<ICollection<UserTestDto>> GetListByTestIdAsync(int testId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var userTestList = await userTestRepository.GetListByTestIdAsync(testId, page, pageSize, cancellationToken);
		var userTestDtoList = userTestList.Select(ut => ut.ToUserTestDto()).ToList();

		return userTestDtoList;
	}

	// public async Task<QuestionDto?> GetQuestionAsync(int userId, int testId)
	// {
	// 	var userTest = await userTestRepository.GetOrCompleteIfExpiredAsync(userId, testId);

	// 	if (userTest.CompletedAt != null)
	// 		return null; // тест уже завершён

	// 	// ищем первый вопрос без выбранных ответов
	// 	var unansweredQuestion = userTest.Questions
	// 		.FirstOrDefault(q => q.SelectedOptions == null || !q.SelectedOptions.Any());

	// 	if (unansweredQuestion == null)
	// 		return null; // все вопросы отвечены

	// 	// загружаем детали вопроса из базы (включая опции)
	// 	var question = await _context.UserQuestions
	// 		.Include(q => q.Question)
	// 			.ThenInclude(q => q.Options)
	// 		.FirstOrDefaultAsync(q => q.Id == unansweredQuestion.Id);

	// 	if (question == null)
	// 		return null;

	// 	// маппинг в DTO
	// 	return new QuestionDto
	// 	{
	// 		Id = question.Question.Id,
	// 		Text = question.Question.Text,
	// 		Options = question.Question.Options
	// 			.Select(o => new OptionDto
	// 			{
	// 				Id = o.Id,
	// 				Text = o.Text
	// 			})
	// 			.ToList()
	// 	};
	// }

}
