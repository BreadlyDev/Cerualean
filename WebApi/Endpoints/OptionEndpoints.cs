using BusinessLogic.Dtos.Option;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class OptionEndpoints
{
    public static void MapOptionEndpoints(this IEndpointRouteBuilder app)
    {
        var optionGroup = app.MapGroup("option").WithOpenApi();

        optionGroup.MapPost("", Create).RequirePermissions(Permission.Create);
        optionGroup.MapGet("/{title}", GetByTitle);
        optionGroup.MapGet("/{id:int}", GetById);
        optionGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
        optionGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
        optionGroup.MapGet("/question/{questionId:int}", GetListByQuestion);
    }

    private static async Task<IResult> Create(
        CreateOptionDto optionRequest,
        IOptionService optionService
    )
    {
        await optionService.AddAsync(optionRequest);
        return Results.Ok();
    }

    private static async Task<IResult> GetById(
        [FromRoute] int id, IOptionService optionService
    )
    {
        var option = await optionService.GetByIdAsync(id);

        if (option == null)
        {
            return Results.NotFound(option);
        }

        return Results.Ok(option);
    }

    private static async Task<IResult> UpdateById(
        [FromRoute] int id,
        UpdateOptionDto optionRequest,
        IOptionService optionService
    )
    {
        await optionService.UpdateByIdAsync(id, optionRequest);
        return Results.Ok();
    }

    private static async Task<IResult> DeleteById(
        [FromRoute] int id,
        IOptionService optionService
    )
    {
        await optionService.DeleteByIdAsync(id);
        return Results.Ok();
    }
    private static async Task<IResult> GetByTitle(
        [FromRoute] string title,
        IOptionService optionService
    )
    {
        var option = await optionService.GetByTitleAsync(title);

        if (option == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(option);
    }

    private static async Task<IResult> GetListByQuestion(
        [FromRoute] int questionId,
        IOptionService optionService
    )
    {
        var options = await optionService.GetListByQuestionAsync(questionId);
        return Results.Ok(options);
    }
}

