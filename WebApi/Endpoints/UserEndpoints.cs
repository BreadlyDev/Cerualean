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
		userGroup.MapPost("/logout", Logout).RequireAuthorization();
		userGroup.MapGet("/profile", GetProfile).RequireAuthorization();
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
		try
		{
			var token = await userService.Login(loginUserRequest);
			context.Response.Cookies.Append("jwt-cookies", token);

			return Results.Ok(token);
		}
		catch (BadHttpRequestException e)
		{
			switch (e.Message)
			{
				case "User not found":
					return Results.NotFound(e.Message);
				case "Wrong credentials":
					return Results.BadRequest(e.Message);
				default:
					return Results.InternalServerError("Internal server error");
			}
		}
	}

	private static IResult Logout(
		HttpContext context
	)
	{
		context.Response.Cookies.Delete("jwt-cookies");

		return Results.Ok("User logged out");
	}

	private static async Task<IResult> GetProfile(ICurrentUserService currentUserService)
	{
		return Results.Ok(currentUserService.UserId);
	}
}
