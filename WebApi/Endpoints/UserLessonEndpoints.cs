using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserLesson;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Endpoints;

public static class UserLessonEndpoints
{
	public static void MapUserLessonEndpoints(this IEndpointRouteBuilder app)
	{
		var userLessonGroup = app.MapGroup("user/lesson")
			.RequireAuthorization()
			.WithOpenApi();

		userLessonGroup.MapPost("", Create);
		userLessonGroup.MapGet("/{lessonId:int}", GetByLessonId);
		userLessonGroup.MapGet("/{lessonId:int}/access", CanUserAccessLesson);
		userLessonGroup.MapGet("", GetListByUserId);
		userLessonGroup.MapGet("/{lessonId:int}/details", GetByUserAndLessonId);
	}

	private static async Task<IResult> Create(
		CreateUserLessonRequest userLessonRequest,
		IUserLessonService userLessonService,
		ICurrentUserService currentUser
	)
	{
		var userId = currentUser.UserId;
		await userLessonService.AddAsync(userLessonRequest, userId);
		return Results.Ok();
	}

	private static async Task<IResult> GetListByUserId(
		IUserLessonService userLessonService,
		ICurrentUserService currentUser,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var userLessonList = await userLessonService.GetListByUserIdAsync(
			currentUser.UserId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize
		);

		return Results.Ok(userLessonList);
	}

	private static async Task<IResult> GetByLessonId(
		[FromRoute] int lessonId,
		IUserLessonService userLessonService,
		ICurrentUserService currentUser,
		[FromQuery] int? page,
		[FromQuery] int? pageSize
	)
	{
		var userLessonList = await userLessonService.GetListByLessonIdAsync(
			lessonId,
			page ?? PaginationDefaults.DefaultPage,
			pageSize ?? PaginationDefaults.DefaultPageSize
		);

		return Results.Ok(userLessonList);
	}

	private static async Task<IResult> GetByUserAndLessonId(
		[FromRoute] int lessonId,
		IUserLessonService userLessonService,
		ICurrentUserService currentUser
	)
	{
		var userLesson = await userLessonService.GetByUserAndLessonIdAsync(currentUser.UserId, lessonId);
		return userLesson is null ? Results.NotFound() : Results.Ok(userLesson);
	}

	private static async Task<IResult> CanUserAccessLesson(
		[FromRoute] int lessonId,
		IUserLessonService userLessonService,
		ICurrentUserService currentUser
	)
	{
		var canAccess = await userLessonService.CanUserAccessLessonAsync(currentUser.UserId, lessonId);
		return Results.Ok(canAccess);
	}
}
