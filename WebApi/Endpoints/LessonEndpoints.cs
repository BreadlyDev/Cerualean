using BusinessLogic.Dtos.Lesson;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Infrastructure.ImageTypes;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class LessonEndpoints
{
    public static void MapLessonEndpoints(this IEndpointRouteBuilder app)
    {
        var lessonGroup = app.MapGroup("lesson").WithOpenApi();

        lessonGroup.MapPost("", Create).RequirePermissions(Permission.Create);
        lessonGroup.MapPost("/image", CreateWithImage).RequirePermissions(Permission.Create);
        lessonGroup.MapGet("", GetListByPage);
        lessonGroup.MapGet("/{title}", GetByTitle);
        lessonGroup.MapGet("/{id:int}", GetById);
        lessonGroup.MapGet("/{id:int}/full", GetFullById);
        lessonGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
        lessonGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
        lessonGroup.MapGet("/course/{courseId:int}", GetListByPageAndCourse);
        lessonGroup.MapGet("/course/{courseId:int}/full", GetListFullByPageAndCourse);
    }

    private static async Task<IResult> Create(
        CreateLessonDto lessonRequest,
        ILessonService lessonService
    )
    {
        await lessonService.AddAsync(lessonRequest);
        return Results.Ok();
    }

    private static async Task<IResult> CreateWithImage(
        [FromForm] IFormFile file,
        [FromForm] CreateLessonDto lessonRequest,
        ILessonService lessonService
    )
    {
        if (file == null || file.Length <= 0)
        {
            return Results.BadRequest("Image must be uploaded");
        }

        if (!ImageAllowedTypes.Types.Contains(file.ContentType))
            return Results.BadRequest("Wrong image format. Choose from (JPEG, PNG, GIF, WebP).");

        var path = Path.Combine("Uploads", "Course", lessonRequest.Title, file.FileName);
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        await lessonService.AddAsync(lessonRequest);

        return Results.Ok("Course with image successfully added");
    }

    private static async Task<IResult> GetById([FromRoute] int id, ILessonService lessonService)
    {
        var lesson = await lessonService.GetByIdAsync(id);

        if (lesson == null)
        {
            return Results.NotFound(lesson);
        }

        return Results.Ok(lesson);
    }

    private static async Task<IResult> GetFullById([FromRoute] int id, ILessonService lessonService)
    {
        var lesson = await lessonService.GetWithFullInfoByIdAsync(id);

        if (lesson == null)
        {
            return Results.NotFound(lesson);
        }

        return Results.Ok(lesson);
    }

    private static async Task<IResult> UpdateById(
        [FromRoute] int id,
        UpdateLessonDto lessonRequest,
        ILessonService lessonService
    )
    {
        await lessonService.UpdateByIdAsync(id, lessonRequest);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteById([FromRoute] int id, ILessonService lessonService)
    {
        await lessonService.DeleteByIdAsync(id);
        return Results.Ok();
    }

    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        ILessonService lessonService
    )
    {
        var lesson = await lessonService.GetByTitleAsync(title);

        if (lesson == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(lesson);
    }

    private static async Task<IResult> GetListByPageAndCourse(
        [FromRoute] int courseId,
        ILessonService lessonService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await lessonService.GetListByPageAndCourseAsync(
            courseId,
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize
        );

        return Results.Ok(lessons);
    }

    private static async Task<IResult> GetListFullByPageAndCourse(
        [FromRoute] int courseId,
        ILessonService lessonService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await lessonService.GetListWithFullInfoByPageAndCourseAsync(
            courseId,
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize
        );

        return Results.Ok(lessons);
    }

    private static async Task<IResult> GetListByPage(
        ILessonService lessonService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await lessonService.GetListByPageAsync(
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize
        );

        return Results.Ok(lessons);
    }
}
