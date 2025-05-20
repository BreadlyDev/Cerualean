using BusinessLogic.Dtos.UserLesson;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class UserLessonMapper
{
	public static UserLessonEntity ToUserLessonFromCreateUserLessonDto(this CreateUserLessonDto lessonDto)
	{
		return new UserLessonEntity
		{
			UserId = lessonDto.UserId,
			LessonId = lessonDto.LessonId
		};
	}

	public static UserLessonEntity ToUserLessonFromUpdateUserLessonDto(this UpdateUserLessonDto lessonDto)
	{
		return new UserLessonEntity
		{
			UserId = lessonDto.UserId,
			LessonId = lessonDto.LessonId
		};
	}

	public static UserLessonDto ToUserLessonDto(this UserLessonEntity lesson)
	{
		return new UserLessonDto(
			lesson.UserId,
			lesson.LessonId
		);
	}
}
