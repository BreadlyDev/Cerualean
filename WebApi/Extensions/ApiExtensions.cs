using System.Text;
using DataAccess.Authorization;
using DataAccess.Enums;
using Infrastructure.Implementations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Endpoints;

namespace WebApi.Extensions;

public static class ApiExtensions
{
	public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
	{
		app.MapUserEndpoints();
		app.MapCourseEndpoints();
		app.MapLessonEndpoints();
		app.MapTheorieEndpoints();
		app.MapPracticeEndpoints();
		app.MapTestEndpoints();
		app.MapQuestionEndpoints();
		app.MapOptionEndpoints();
		app.MapUserLessonEndpoints();
		app.MapUserPracticeEndpoints();
		app.MapUserTestEndpoints();
		app.MapUserQuestionEndpoints();
		app.MapUserOptionEndpoints();
	}

	public static void AddApiAuthentication(
		this IServiceCollection services,
		IOptions<JwtOptions> jwtOptions
	)
	{
		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
			.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
			{
				options.TokenValidationParameters = new()
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)
					)
				};

				options.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						context.Token = context.Request.Cookies["jwt-cookies"];

						return Task.CompletedTask;
					}
				};
			});

		services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
		services.AddAuthorization();
	}

	public static IEndpointConventionBuilder RequirePermissions<TBuilder>(
		this TBuilder builder, params Permission[] permissions)
			where TBuilder : IEndpointConventionBuilder
	{
		return builder.RequireAuthorization(policy =>
			policy.AddRequirements(new PermissionRequirement(permissions)));
	}
}

