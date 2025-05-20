using Infrastructure.Abstractions;
using Infrastructure.Implementations;
using Infrastructure.Pagination;

namespace Infrastructure.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var paginationSection = configuration.GetSection("Pagination");
        var paginationOptions = paginationSection.Get<PaginationOptions>();
        PaginationDefaults.Configure(paginationOptions);
        services.Configure<PaginationOptions>(paginationSection);

        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
        return services;
    }
}

