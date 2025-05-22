using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserTest;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

namespace WebApi.Endpoints;

public static class UserTestEndpoints
{
	public static void MapUserTestEndpoints(this IEndpointRouteBuilder app)
	{
		var userTestGroup = app.MapGroup("user/test")
			.RequireAuthorization()
			.WithOpenApi();

		userTestGroup.MapPost("", Create);
		userTestGroup.MapGet("{testId:int}", GetListByTestId);
		userTestGroup.MapGet("/me", GetListByCurrentUserId);
		userTestGroup.MapGet("{testId:int}/me", GetByCurrentUserAndTestId);

		userTestGroup.MapPost("{testId:int}/start", StartTest);
		userTestGroup.MapPost("{testId:int}/complete", CompleteTest);
	}

	private static async Task<IResult> Create(
		CreateUserTestRequest userTestRequest,
		IUserTestService userTestService,
		ICurrentUserService currentUser
	)
	{
		var userId = currentUser.UserId;
		await userTestService.AddAsync(userTestRequest, userId);
		return Results.Ok();
	}

	private static async Task<IResult> GetListByCurrentUserId(
		IUserTestService userTestService,
		ICurrentUserService currentUser,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var list = await userTestService.GetListByUserIdAsync(
			currentUser.UserId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize);
		return Results.Ok(list);
	}

	private static async Task<IResult> GetListByTestId(
		[FromRoute] int testId,
		IUserTestService userTestService,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var list = await userTestService.GetListByTestIdAsync(
			testId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize);
		return Results.Ok(list);
	}

	private static async Task<IResult> GetByCurrentUserAndTestId(
		[FromRoute] int testId,
		IUserTestService userTestService,
		ICurrentUserService currentUser
	)
	{
		var userTest = await userTestService.GetByUserAndTestIdAsync(currentUser.UserId, testId);
		return userTest is null ? Results.NotFound() : Results.Ok(userTest);
	}

	private static async Task<IResult> StartTest(
		[FromRoute] int testId,
		IUserTestService userTestService,
		ICurrentUserService currentUser
	)
	{
		await userTestService.StartAsync(currentUser.UserId, testId);
		return Results.Ok();
	}

	private static async Task<IResult> CompleteTest(
		[FromRoute] int testId,
		IUserTestService userTestService,
		ICurrentUserService currentUser
	)
	{
		var userTestDto = await userTestService.CompleteAsync(currentUser.UserId, testId);
		return Results.Ok(userTestDto);
	}
}
