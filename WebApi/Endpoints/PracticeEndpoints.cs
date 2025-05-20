using BusinessLogic.Dtos.Practice;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class PracticeEndpoints
{
    public static void MapPracticeEndpoints(this IEndpointRouteBuilder app)
    {
        var practiceGroup = app.MapGroup("practice").WithOpenApi();

        practiceGroup.MapPost("", Create).RequirePermissions(Permission.Create);
        practiceGroup.MapGet("", GetListByPage);
        practiceGroup.MapGet("/{title}", GetByTitle);
        practiceGroup.MapGet("/{id:int}", GetById);
        practiceGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
        practiceGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
        practiceGroup.MapGet("/lesson/{lessonId:int}", GetListByPageAndLesson);
    }

    private static async Task<IResult> Create(
        CreatePracticeDto practiceRequest,
        IPracticeService practiceService
    )
    {
        await practiceService.AddAsync(practiceRequest);
        return Results.Ok();
    }

    private static async Task<IResult> GetById(
        [FromRoute] int id, IPracticeService practiceService
    )
    {
        var practice = await practiceService.GetByIdAsync(id);

        if (practice == null)
        {
            return Results.NotFound(practice);
        }

        return Results.Ok(practice);
    }

    private static async Task<IResult> UpdateById(
        [FromRoute] int id,
        UpdatePracticeDto practiceRequest,
        IPracticeService practiceService
    )
    {
        await practiceService.UpdateByIdAsync(id, practiceRequest);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteById(
        [FromRoute] int id,
        IPracticeService practiceService
    )
    {
        await practiceService.DeleteByIdAsync(id);
        return Results.Ok();
    }

    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        IPracticeService practiceService
    )
    {
        var practice = await practiceService.GetByTitleAsync(title);

        if (practice == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(practice);
    }

    private static async Task<IResult> GetListByPageAndLesson(
        [FromRoute] int lessonId,
        IPracticeService practiceService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await practiceService.GetListByPageAndLessonAsync(
            lessonId,
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }

    private static async Task<IResult> GetListByPage(
        IPracticeService practiceService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await practiceService.GetListByPageAsync(
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }
}

