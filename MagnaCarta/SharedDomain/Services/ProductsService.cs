using SharedDomain.Entities;

namespace SharedDomain.Services;

public class ProductsService
{
    public Task<Product[]> GetAllProducts()
    {
        var products = Array.Empty<Product>();
        return Task.FromResult(products);
    }
}