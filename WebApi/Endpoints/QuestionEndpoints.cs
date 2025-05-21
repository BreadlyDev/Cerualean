using BusinessLogic.Dtos.Question;
using DataAccess.Abstractions;
using DataAccess.Enums;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class QuestionEndpoints
{
	public static void MapQuestionEndpoints(this IEndpointRouteBuilder app)
	{
		var questionGroup = app.MapGroup("question").WithOpenApi();

		questionGroup.MapPost("", Create).RequirePermissions(Permission.Create);
		questionGroup.MapGet("/{title}", GetByTitle);
		questionGroup.MapGet("/{id:int}", GetById);
		questionGroup.MapGet("/{id:int}/options", GetWithOptionsById);
		questionGroup.MapPut("/{id:int}", UpdateById).RequirePermissions(Permission.Update);
		questionGroup.MapDelete("/{id:int}", DeleteById).RequirePermissions(Permission.Delete);
		questionGroup.MapGet("/test/{testId:int}", GetListByTest);
		questionGroup.MapGet("/test/{testId:int}/options", GetListWithOptionsByTest);
	}

	private static async Task<IResult> Create(
		[FromBody] CreateQuestionDto questionRequest,
		IQuestionService questionService
	)
	{
		await questionService.AddAsync(questionRequest);
		return Results.Ok();
	}

	private static async Task<IResult> GetById(
		[FromRoute] int id, IQuestionService questionService
	)
	{
		var question = await questionService.GetByIdAsync(id);

		if (question == null)
		{
			return Results.NotFound(question);
		}

		return Results.Ok(question);
	}

	private static async Task<IResult> GetWithOptionsById(
		[FromRoute] int id, IQuestionService questionService
	)
	{
		var question = await questionService.GetWithOptionsByIdAsync(id);

		if (question == null)
		{
			return Results.NotFound(question);
		}

		return Results.Ok(question);
	}

	private static async Task<IResult> UpdateById(
		[FromRoute] int id,
		UpdateQuestionDto questionRequest,
		IQuestionService questionService
	)
	{
		await questionService.UpdateByIdAsync(id, questionRequest);
		return Results.Ok();
	}

	private static async Task<IResult> DeleteById(
		[FromRoute] int id,
		IQuestionService questionService
	)
	{
		await questionService.DeleteByIdAsync(id);
		return Results.Ok();
	}
	private static async Task<IResult> GetByTitle(
		[FromRoute] string title,
		IQuestionService questionService
	)
	{
		var question = await questionService.GetByTitleAsync(title);

		if (question == null)
		{
			return Results.NotFound();
		}

		return Results.Ok(question);
	}

	private static async Task<IResult> GetListByTest(
		[FromRoute] int testId,
		IQuestionService questionService
	)
	{
		var questions = await questionService.GetListByTestAsync(testId);
		return Results.Ok(questions);
	}

	private static async Task<IResult> GetListWithOptionsByTest(
		[FromRoute] int testId,
		IQuestionService questionService
	)
	{
		var questions = await questionService.GetListWithOptionsByTestAsync(testId);
		return Results.Ok(questions);
	}
}

