using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.Theorie;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class TheorieEndpoints
{
    public static void MapTheorieEndpoints(this IEndpointRouteBuilder app)
    {
        var theorieGroup = app.MapGroup("theorie").WithOpenApi();

        theorieGroup.MapPost("", Create).RequirePermissions(Permission.Create);
        theorieGroup.MapGet("", GetListByPage);
        theorieGroup.MapGet("/{title}", GetByTitle);
        theorieGroup.MapGet("/{id:int}", GetById);
        theorieGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
        theorieGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
        theorieGroup.MapGet("/lesson/{lessonId:int}", GetListByPageAndLesson);
    }

    private static async Task<IResult> Create(
        CreateTheorieDto theorieRequest,
        ITheorieService theorieService
    )
    {
        await theorieService.AddAsync(theorieRequest);
        return Results.Ok();
    }

    private static async Task<IResult> GetById(
        [FromRoute] int id, ITheorieService theorieService
    )
    {
        var theorie = await theorieService.GetByIdAsync(id);

        if (theorie == null)
        {
            return Results.NotFound(theorie);
        }

        return Results.Ok(theorie);
    }

    private static async Task<IResult> UpdateById(
        [FromRoute] int id,
        UpdateTheorieDto theorieRequest,
        ITheorieService theorieService
    )
    {
        await theorieService.UpdateByIdAsync(id, theorieRequest);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteById(
        [FromRoute] int id,
        ITheorieService theorieService
    )
    {
        await theorieService.DeleteByIdAsync(id);
        return Results.Ok();
    }

    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        ITheorieService theorieService
    )
    {
        var theorie = await theorieService.GetByTitleAsync(title);

        if (theorie == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(theorie);
    }

    private static async Task<IResult> GetListByPageAndLesson(
        [FromRoute] int lessonId,
        ITheorieService theorieService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await theorieService.GetListByPageAndLessonAsync(
            lessonId,
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }

    private static async Task<IResult> GetListByPage(
        ITheorieService theorieService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await theorieService.GetListByPageAsync(
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }
}

