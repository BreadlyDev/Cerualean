using DataAccess.Abstractions;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extensions;

public static class DataAccessExtensions
{
	public static IServiceCollection AddDataAccess(
		this IServiceCollection services,
		IConfiguration configuration
	)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<ICourseRepository, CourseRepository>();
		services.AddScoped<ILessonRepository, LessonRepository>();
		services.AddScoped<ITheorieRepository, TheorieRepository>();
		services.AddScoped<IPracticeRepository, PracticeRepository>();
		services.AddScoped<ITestRepository, TestRepository>();
		services.AddScoped<IQuestionRepository, QuestionRepository>();
		services.AddScoped<IOptionRepository, OptionRepository>();
		services.AddScoped<IUserTestRepository, UserTestRepository>();
		services.AddScoped<IUserQuestionRepository, UserQuestionRepository>();
		services.AddScoped<IUserOptionRepository, UserOptionRepository>();
		services.AddScoped<IUserPracticeRepository, UserPracticeRepository>();
		services.AddScoped<IUserLessonRepository, UserLessonRepository>();


		services.AddDbContext<AppDbContext>(x =>
		{
			var connectionString = configuration.GetConnectionString("DefaultConnectionString");
			x.UseNpgsql(connectionString);
		});
		return services;
	}
}

