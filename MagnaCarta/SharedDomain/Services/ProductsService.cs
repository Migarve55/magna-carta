using SharedDomain.Entities;
using SharedDomain.Repositories;

namespace SharedDomain.Services;

internal class ProductsService : IProductsService
{
    private readonly IRepository<Product> _repository;

    public ProductsService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<Product?> GetProduct(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IReadOnlyCollection<Product>> GetAllProducts()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product> AddProduct(Product product)
    {
        return await _repository.CreateAsync(product);
    }

    public async Task UpdateProduct(Product product)
    {
        await _repository.UpdateAsync(product);
    }

    public async Task DeleteProduct(int id)
    {
        await _repository.DeleteAsync(id);
    }
}