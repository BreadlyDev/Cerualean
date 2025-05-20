using DataAccess;
using DataAccess.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace WebApi.Data;

public class SampleContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnectionString");
        builder.UseNpgsql(connectionString, b => b.MigrationsAssembly("WebApi"));

        var authOptions = new AuthorizationOptions();
        configuration.GetSection(nameof(AuthorizationOptions)).Bind(authOptions);

        return new AppDbContext(builder.Options, Options.Create(authOptions));
    }
}


