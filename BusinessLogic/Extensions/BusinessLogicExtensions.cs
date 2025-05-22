using BusinessLogic.Abstractions;
using BusinessLogic.Services;
using DataAccess.Abstractions;

namespace BusinessLogic.Extensions;

public static class BusinessLogicExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IPracticeService, PracticeService>();
        services.AddScoped<ITheorieService, TheorieService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IOptionService, OptionService>();
        services.AddScoped<IUserLessonService, UserLessonService>();
        services.AddScoped<IUserPracticeService, UserPracticeService>();
        services.AddScoped<IUserTestService, UserTestService>();
        services.AddScoped<IUserQuestionService, UserQuestionService>();
        services.AddScoped<IUserOptionService, UserOptionService>();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICodeRunnerService, CodeRunnerService>();

        return services;
    }
}
