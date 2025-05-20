using System.Security.Claims;
using BusinessLogic.Abstractions;
using BusinessLogic.Dtos.User;

namespace WebApi.Endpoints;

public static class UserEndpoints
{
	public static void MapUserEndpoints(this IEndpointRouteBuilder app)
	{
		var userGroup = app.MapGroup("user").WithOpenApi();

		userGroup.MapPost("/register", Register);
		userGroup.MapPost("/login", Login);

		var privateGroup = app.MapGroup("user")
							  .RequireAuthorization()
							  .WithOpenApi();

		privateGroup.MapGet("/profile", GetProfile);
	}

	private static async Task<IResult> Register(
		RegisterUserDto registerUserRequest,
		IUserService userService
	)
	{
		await userService.Register(registerUserRequest);
		return Results.Ok();
	}

	private static async Task<IResult> Login(
		LoginUserDto loginUserRequest,
		IUserService userService,
		HttpContext context
	)
	{
		var token = await userService.Login(loginUserRequest);
		context.Response.Cookies.Append("jwt-cookies", token);

		return Results.Ok(token);
	}

	private static async Task<IResult> GetProfile(IUserService userService, HttpContext context)
	{
		var userId = GetUserId(context);
		var user = await userService.GetById(userId);
		return Results.Ok(user);
	}

	private static int GetUserId(HttpContext context)
	{
		var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)
						  ?? throw new UnauthorizedAccessException("User ID not found in token");

		return int.Parse(userIdClaim.Value);
	}
}

