using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SharedDomain.Data;

namespace SharedDomain.Extensions;

public static class AppExtensions
{
    public static WebApplication SeedDatabase(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        DataBaseSeeder seeder = scope.ServiceProvider.GetRequiredService<DataBaseSeeder>();
        seeder.SeedDatabase().Wait();
        return app;
    }
}