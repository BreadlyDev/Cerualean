using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserTest;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

public static class UserQuestionEndpoints
{
	public static void MapUserQuestionEndpoints(this IEndpointRouteBuilder app)
	{
		var userQuestionGroup = app.MapGroup("user/question").WithOpenApi();

		userQuestionGroup.MapPost("", Create);
		userQuestionGroup.MapGet("/userTestId/{userTestId:int}/question/{questionId:int}", GetByUserAndQuestionId);
		userQuestionGroup.MapGet("/userTestId/{userTestId:int}", GetListByUserTestId);
		userQuestionGroup.MapGet("/questionId/{questionId:int}", GetListByQuestionId);
	}

	private static async Task<IResult> Create(
		CreateUserQuestionDto userQuestionRequest,
		IUserQuestionService userQuestionService
	)
	{
		await userQuestionService.AddAsync(userQuestionRequest);
		return Results.Ok();
	}

	private static async Task<IResult> GetListByUserTestId(
		[FromRoute] int userTestId, IUserQuestionService userQuestionService,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var userQuestionList = await userQuestionService.GetListByUserTestIdAsync(
			userTestId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize
		);

		return Results.Ok(userQuestionList);
	}

	private static async Task<IResult> GetListByQuestionId(
		[FromRoute] int questionId, IUserQuestionService userQuestionService,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var userQuestionList = await userQuestionService.GetListByQuestionIdAsync(
			questionId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize
		);

		return Results.Ok(userQuestionList);
	}

	private static async Task<IResult> GetByUserAndQuestionId(
		[FromRoute] int questionId, [FromRoute] int userTestId, IUserQuestionService userQuestionService
	)
	{
		var userQuestion = await userQuestionService.GetByUserTestAndQuestionIdAsync(userTestId, questionId);
		if (userQuestion == null)
		{
			return Results.NotFound();
		}

		return Results.Ok(userQuestion);
	}
}
