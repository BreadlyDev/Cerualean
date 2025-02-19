using Cerualean.Data;
using Cerualean.Domain.CourseCategoryModule;
using Cerualean.Domain.CourseCategoryModule.Interfaces;
using Cerualean.Domain.CourseModule;
using Cerualean.Domain.CourseModule.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Cerulean", Version = "v1" });
});
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICourseCategoryRepository, CourseCategoryRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => 
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Cerulean v1");
    options.RoutePrefix = string.Empty;
});
app.MapControllers();

app.Run();
