using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserOption;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class UserOptionEndpoints
{
	public static void MapUserOptionEndpoints(this IEndpointRouteBuilder app)
	{
		var userOptionGroup = app.MapGroup("user/option")
			.RequireAuthorization()
			.WithOpenApi();

		userOptionGroup.MapPost("", Create);
		userOptionGroup.MapGet("/question/{userQuestionId:int}/option/{optionId:int}", GetByUserQuestionAndOptionId);
		userOptionGroup.MapGet("/question/{userQuestionId:int}", GetListByUserQuestionId);
		userOptionGroup.MapGet("/option/{optionId:int}", GetListByOptionId);
	}

	private static async Task<IResult> Create(
		CreateUserOptionDto userOptionRequest,
		IUserOptionService userOptionService
	)
	{
		await userOptionService.AddAsync(userOptionRequest);
		return Results.Ok();
	}

	private static async Task<IResult> GetListByUserQuestionId(
		[FromRoute] int userQuestionId,
		IUserOptionService userOptionService,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var userOptionList = await userOptionService.GetListByUserQuestionIdAsync(
			userQuestionId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize
		);

		return Results.Ok(userOptionList);
	}

	private static async Task<IResult> GetListByOptionId(
		[FromRoute] int optionId,
		IUserOptionService userOptionService,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var userOptionList = await userOptionService.GetListByOptionIdAsync(
			optionId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize
		);

		return Results.Ok(userOptionList);
	}

	private static async Task<IResult> GetByUserQuestionAndOptionId(
		[FromRoute] int userQuestionId,
		[FromRoute] int optionId,
		IUserOptionService userOptionService
	)
	{
		var userOption = await userOptionService.GetByUserQuestionAndOptionIdAsync(userQuestionId, optionId);
		return userOption is null ? Results.NotFound() : Results.Ok(userOption);
	}
}
