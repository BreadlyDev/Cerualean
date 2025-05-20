using BusinessLogic.Dtos.Test;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class TestMapper
{
    public static TestEntity ToTestFromCreateTestDto(this CreateTestDto testDto)
    {
        return new TestEntity
        {
            Title = testDto.Title,
            Duration = testDto.Duration,
            Level = testDto.Level,
            LessonId = testDto.LessonId
        };
    }

    public static TestEntity ToTestFromUpdateTestDto(this UpdateTestDto testDto)
    {
        return new TestEntity
        {
            Title = testDto.Title,
            Duration = testDto.Duration,
            Level = testDto.Level,
            LessonId = testDto.LessonId
        };
    }

    public static TestDto ToTestDto(this TestEntity test)
    {
        return new TestDto(
            test.Id,
            test.Title,
            test.Duration,
            test.Level,
            test.LessonId
        );
    }
}

