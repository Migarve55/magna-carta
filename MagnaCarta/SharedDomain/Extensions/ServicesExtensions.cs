using Microsoft.Extensions.DependencyInjection;
using SharedDomain.Data;
using SharedDomain.Entities;
using SharedDomain.Repositories;
using SharedDomain.Services;

namespace SharedDomain.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<DataBaseSeeder>();
        
        // Services
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<ITablesService, TablesService>();
        services.AddScoped<IOrdersService, OrdersService>();

        // Repositories
        services.AddScoped<IRepository<Product>, ProductsRepository>();
        services.AddScoped<IRepository<Table>, TablesRepository>();
        services.AddScoped<IRepository<Order>, OrdersRepository>();
        services.AddScoped<IRepository<OrderDetail>, OrdersDetailsRepository>();
        
        return services;
    }
}