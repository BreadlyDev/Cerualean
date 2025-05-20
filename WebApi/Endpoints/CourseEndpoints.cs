using BusinessLogic.Dtos.Course;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class CourseEndpoints
{
    public static void MapCourseEndpoints(this IEndpointRouteBuilder app)
    {
        var courseGroup = app.MapGroup("course").WithOpenApi();

        courseGroup.MapPost("", Create).RequirePermissions(Permission.Create);
        courseGroup.MapGet("", GetListByPage);
        courseGroup.MapGet("/{title}", GetByTitle);
        courseGroup.MapGet("/{id:int}", GetById);
        courseGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
        courseGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
    }

    private static async Task<IResult> Create(
        CreateCourseDto courseRequest,
        ICourseService courseService
    )
    {
        await courseService.AddAsync(courseRequest);
        return Results.Ok();
    }

    private static async Task<IResult> GetById(
        [FromRoute] int id, ICourseService courseService
    )
    {
        var course = await courseService.GetByIdAsync(id);

        if (course == null)
        {
            return Results.NotFound(course);
        }

        return Results.Ok(course);
    }

    private static async Task<IResult> UpdateById(
        [FromRoute] int id,
        UpdateCourseDto courseRequest,
        ICourseService courseService
    )
    {
        await courseService.UpdateByIdAsync(id, courseRequest);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteById(
        [FromRoute] int id,
        ICourseService courseService
    )
    {
        await courseService.DeleteByIdAsync(id);
        return Results.Ok();
    }

    private static async Task<IResult> GetListByPage(
        ICourseService courseService,
        [FromQuery] int? page,
        [FromQuery] int? pageSize
    )
    {
        var lessons = await courseService.GetListByPageAsync(
            page ?? PaginationDefaults.DefaultPage,
            pageSize ?? PaginationDefaults.DefaultPageSize);

        return Results.Ok(lessons);
    }

    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        ICourseService courseService
    )
    {
        var course = await courseService.GetByTitleAsync(title);

        if (course == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(course);
    }
}

