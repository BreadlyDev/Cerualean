using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.UserLesson;
using DataAccess.Enums;
using Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using WebApi.Extensions;

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
		CreateUserLessonDto userLessonRequest,
		IUserLessonService userLessonService
	)
	{
		await userLessonService.AddAsync(userLessonRequest);
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
