using BusinessLogic.Dtos.Theorie;
using DataAccess.Entities;

namespace BusinessLogic.Mappers;

public static class TheorieMapper
{
    public static TheorieEntity ToTheorieFromCreateTheorieDto(this CreateTheorieDto theorieDto)
    {
        return new TheorieEntity
        {
            Title = theorieDto.Title,
            SubTitle = theorieDto.SubTitle,
            Content = theorieDto.Content,
            Format = theorieDto.Format,
            LessonId = theorieDto.LessonId
        };
    }

    public static TheorieEntity ToTheorieFromUpdateTheorieDto(this UpdateTheorieDto theorieDto)
    {
        return new TheorieEntity
        {
            Title = theorieDto.Title,
            SubTitle = theorieDto.SubTitle,
            Content = theorieDto.Content,
            Format = theorieDto.Format,
            LessonId = theorieDto.LessonId
        };
    }

    public static TheorieDto ToTheorieDto(this TheorieEntity theorie)
    {
        return new TheorieDto(
            theorie.Id,
            theorie.Title,
            theorie.SubTitle,
            theorie.Content,
            theorie.Format,
            theorie.LessonId
        );
    }
}

