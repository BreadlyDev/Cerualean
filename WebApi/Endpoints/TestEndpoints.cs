using BusinessLogic.Dtos.Test;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class TestEndpoints
{
    public static void MapTestEndpoints(this IEndpointRouteBuilder app)
    {
        var testGroup = app.MapGroup("test").WithOpenApi();

        testGroup.MapPost("", Create).RequirePermissions(Permission.Create);
        testGroup.MapGet("", GetListByPage);
        testGroup.MapGet("/{title}", GetByTitle);
        testGroup.MapGet("/{id:int}", GetById);
        testGroup.MapGet("/{id:int}/questions", GetWithQuestionsById);
        testGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
        testGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
        testGroup.MapGet("/lesson/{lessonId:int}", GetListByPageAndLesson);
    }

    private static async Task<IResult> Create(
        CreateTestDto testRequest,
        ITestService testService
    )
    {
        await testService.AddAsync(testRequest);
        return Results.Ok();
    }

    private static async Task<IResult> GetById(
        [FromRoute] int id, ITestService testService
    )
    {
        var test = await testService.GetByIdAsync(id);

        if (test == null)
        {
            return Results.NotFound(test);
        }

        return Results.Ok(test);
    }

    private static async Task<IResult> GetWithQuestionsById(
        [FromRoute] int id, ITestService testService
    )
    {
        var test = await testService.GetWithQuestionsByIdAsync(id);

        if (test == null)
        {
            return Results.NotFound(test);
        }

        return Results.Ok(test);
    }

    private static async Task<IResult> UpdateById(
        [FromRoute] int id,
        UpdateTestDto testRequest,
        ITestService testService
    )
    {
        await testService.UpdateByIdAsync(id, testRequest);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteById(
        [FromRoute] int id,
        ITestService testService
    )
    {
        await testService.DeleteByIdAsync(id);
        return Results.Ok();
    }
    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        ITestService testService
    )
    {
        var test = await testService.GetByTitleAsync(title);

        if (test == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(test);
    }

    private static async Task<IResult> GetListByPageAndLesson(
        [FromRoute] int lessonId,
        ITestService testService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await testService.GetListByPageAndLessonAsync(
            lessonId,
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }

    private static async Task<IResult> GetListByPage(
        ITestService testService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await testService.GetListByPageAsync(
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }
}
