using Microsoft.Extensions.DependencyInjection;
using SharedDomain.Entities;
using SharedDomain.Repositories;
using SharedDomain.Services;

namespace SharedDomain.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IProductsService, ProductsService>();

        // Repositories
        services.AddScoped<IRepository<Product>, ProductsRepository>();
        
        return services;
    }
}