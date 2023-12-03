using SharedDomain.Entities;

namespace SharedDomain.Services;

public interface IProductsService
{
    Task<Product?> GetProduct(int id);
    Task<IReadOnlyCollection<Product>> GetAllProducts();
    Task<Product> AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int id);
}