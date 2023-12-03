namespace SharedDomain.Repositories;

public interface IRepository<T> where T : class
{
    public Task<T> CreateAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task<IReadOnlyCollection<T>> GetAllAsync();
    public Task<T?> GetByIdAsync(int id);
    public Task DeleteAsync(int id);
}