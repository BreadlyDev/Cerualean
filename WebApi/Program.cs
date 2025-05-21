using BusinessLogic.Extensions;
using DataAccess.Authorization;
using DataAccess.Extensions;
using Infrastructure.Extensions;
using Infrastructure.Implementations;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.Extensions.Options;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.Configure<AuthorizationOptions>(
	builder.Configuration.GetSection(nameof(AuthorizationOptions)));


builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddBusinessLogic();


builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddApiAuthentication(builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>());

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAlmostEverything", policy =>
	{
		policy
			.AllowAnyOrigin()
			.AllowAnyMethod()
			.AllowAnyHeader();
	});
});


var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();
app.UseCookiePolicy(new CookiePolicyOptions
{
	MinimumSameSitePolicy = SameSiteMode.Strict,
	HttpOnly = HttpOnlyPolicy.Always,
	Secure = CookieSecurePolicy.Always
});

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAlmostEverything");

app.AddMappedEndpoints();
app.MapGet("", () =>
{

});

// app.MapPost("post", () =>
// {
//     return Results.Ok("ok");
// }).RequirePermissions(Permission.Create);

app.Run();
