using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Application.DTOs;
using Application.Services;
using Infrastructure;
using DataAccess;

var cts = new CancellationTokenSource();

// Завершение по Ctrl+C
Console.CancelKeyPress += (sender, args) =>
{
    Console.WriteLine("\nВыход по Ctrl+C...");
    args.Cancel = true;
    cts.Cancel();
};

// Хост + DI + конфигурация
var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: true);
    })
    .ConfigureServices((ctx, services) =>
    {
        var config = ctx.Configuration;

        // Твой сервис и зависимости
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<UserService>();

        // Подключение к БД
        services.AddDbContext<AppContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
    })
    .Build();

Console.WriteLine("== Консоль для создания админов ==");
Console.WriteLine("Нажмите Ctrl+C для выхода");

while (!cts.IsCancellationRequested)
{
    using var scope = host.Services.CreateScope();
    var userService = scope.ServiceProvider.GetRequiredService<UserService>();

    Console.Write("\nEmail: ");
    var email = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(email)) continue;

    Console.Write("Пароль: ");
    var password = Console.ReadLine();

    Console.Write("Имя: ");
    var name = Console.ReadLine();

    var dto = new AdminUserDto
    {
        Email = email!,
        Password = password!,
        Name = name!
    };

    try
    {
        await userService.RegisterAdmin(dto, cts.Token);
        Console.WriteLine("✅ Админ создан успешно.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Ошибка: {ex.Message}");
    }
}
