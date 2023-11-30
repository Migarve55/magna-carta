using Microsoft.Extensions.DependencyInjection;
using SharedDomain.Services;

namespace SharedDomain.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<ProductsService>();

        return services;
    }
}