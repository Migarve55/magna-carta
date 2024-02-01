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
        services.AddScoped<ITablesService, TablesService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IAllergensService, AllergensService>();

        // Repositories
        services.AddScoped<IRepository<Product>, ProductsRepository>();
        services.AddScoped<IRepository<Table>, TablesRepository>();
        services.AddScoped<IRepository<Order>, OrdersRepository>();
        services.AddScoped<IRepository<OrderDetail>, OrdersDetailsRepository>();
        services.AddScoped<IRepository<Allergen>, AllergensRepository>();
        
        return services;
    }
}