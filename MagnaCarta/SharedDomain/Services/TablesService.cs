using SharedDomain.Entities;
using SharedDomain.Repositories;

namespace SharedDomain.Services;

internal class TablesService : ITablesService
{
    private readonly IRepository<Table> _repository;

    public TablesService(IRepository<Table> repository)
    {
        _repository = repository;
    }

    public async Task<Table?> GetTable(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<IReadOnlyCollection<Table>> GetAllTables()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Table> AddTable(Table table)
    {
        return await _repository.CreateAsync(table);
    }

    public async Task UpdateTable(Table table)
    {
        await _repository.UpdateAsync(table);
    }

    public async Task DeleteTable(int id)
    {
        await _repository.DeleteAsync(id);
    }
}