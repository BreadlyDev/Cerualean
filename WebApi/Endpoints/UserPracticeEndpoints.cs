using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserLesson;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

public static class UserPracticeEndpoints
{
	public static void MapUserPracticeEndpoints(this IEndpointRouteBuilder app)
	{
		var userPracticeGroup = app.MapGroup("user/practice")
			.RequireAuthorization()
			.WithOpenApi();

		userPracticeGroup.MapPost("", Create);
		userPracticeGroup.MapGet("/practice/{practiceId:int}", GetListByPracticeId);
		userPracticeGroup.MapGet("/practice/{practiceId:int}/user", GetByUserAndPracticeId);
		userPracticeGroup.MapGet("/me", GetListByCurrentUserId);
	}

	private static async Task<IResult> Create(
		CreateUserPracticeDto userPracticeRequest,
		IUserPracticeService userPracticeService,
		ICurrentUserService currentUser
	)
	{
		await userPracticeService.AddAsync(userPracticeRequest);
		return Results.Ok();
	}

	private static async Task<IResult> GetListByCurrentUserId(
		IUserPracticeService userPracticeService,
		ICurrentUserService currentUser,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var list = await userPracticeService.GetListByUserIdAsync(
			currentUser.UserId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize);
		return Results.Ok(list);
	}

	private static async Task<IResult> GetListByPracticeId(
		[FromRoute] int practiceId,
		IUserPracticeService userPracticeService,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var list = await userPracticeService.GetListByPracticeIdAsync(
			practiceId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize);
		return Results.Ok(list);
	}

	// Получить запись по practiceId и текущему пользователю (UserId из JWT)
	private static async Task<IResult> GetByUserAndPracticeId(
		[FromRoute] int practiceId,
		IUserPracticeService userPracticeService,
		ICurrentUserService currentUser
	)
	{
		var userPractice = await userPracticeService.GetByUserAndPracticeIdAsync(currentUser.UserId, practiceId);
		return userPractice is null ? Results.NotFound() : Results.Ok(userPractice);
	}
}
