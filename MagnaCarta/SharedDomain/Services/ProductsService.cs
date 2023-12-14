using SharedDomain.Entities;
using SharedDomain.Repositories;

namespace SharedDomain.Services;

internal class ProductsService : IProductsService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<OrderDetail> _orderDetailsRepository;

    public ProductsService(IRepository<Product> productRepository, 
        IRepository<OrderDetail> orderDetailsRepository)
    {
        _productRepository = productRepository;
        _orderDetailsRepository = orderDetailsRepository;
    }

    public async Task<Product?> GetProduct(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<IReadOnlyCollection<Product>> GetAllProducts()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> AddProduct(Product product)
    {
        return await _productRepository.CreateAsync(product);
    }

    public async Task UpdateProduct(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }

    public async Task<DeleteEntityResult> DeleteProduct(int id)
    {
        Product? product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            return DeleteEntityResult.Fail($"El producto con id({id}) no existe");
        }

        IReadOnlyCollection<OrderDetail> orderDetails = await _orderDetailsRepository.GetAllAsync();
        if (orderDetails.Any(od => od.ProductId == product.Id))
        {
            return DeleteEntityResult.Fail($"El producto con ya está siendo usado en un pedido");
        }
        
        await _productRepository.DeleteAsync(id);
        return DeleteEntityResult.Success();
    }
}