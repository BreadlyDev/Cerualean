using BusinessLogic.Dtos.Lesson;
using BusinessLogic.Mappers;
using DataAccess.Abstractions;

namespace BusinessLogic.Services;

internal class LessonService(ILessonRepository lessonRepository) : ILessonService
{
	public async Task AddAsync(CreateLessonDto lesson, CancellationToken cancellationToken = default)
	{
		await lessonRepository.AddAsync(lesson.ToLessonFromCreateLessonDto(), cancellationToken);
	}

	public async Task DeleteByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		await lessonRepository.DeleteByIdAsync(id, cancellationToken);
	}

	public async Task<LessonDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		var lesson = await lessonRepository.GetByIdAsync(id, cancellationToken);

		if (lesson == null)
		{
			return null;
		}

		return lesson.ToLessonDto();
	}

	public async Task<LessonDto?> GetByTitleAsync(string title, CancellationToken cancellationToken = default)
	{
		var lesson = await lessonRepository.GetByTitleAsync(title, cancellationToken);

		if (lesson == null)
		{
			return null;
		}

		return lesson.ToLessonDto();
	}

	public async Task<ICollection<LessonDto>> GetListByPageAndCourseAsync(int courseId, int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var lessonList = await lessonRepository.GetListByPageAndCourseAsync(courseId, page, pageSize, cancellationToken);
		var lessonDtoList = lessonList.Select(l => l.ToLessonDto()).ToList();
		return lessonDtoList;
	}

	public async Task<ICollection<LessonDto>> GetListByPageAsync(int page, int pageSize, CancellationToken cancellationToken = default)
	{
		var lessonList = await lessonRepository.GetListByPageAsync(page, pageSize, cancellationToken);
		var lessonDtoList = lessonList.Select(l => l.ToLessonDto()).ToList();
		return lessonDtoList;
	}

	public async Task UpdateByIdAsync(int id, UpdateLessonDto newLesson, CancellationToken cancellationToken = default)
	{
		await lessonRepository.UpdateByIdAsync(id, newLesson.ToLessonFromUpdateLessonDto(), cancellationToken);
	}
}

