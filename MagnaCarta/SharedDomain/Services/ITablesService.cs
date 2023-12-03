using SharedDomain.Entities;

namespace SharedDomain.Services;

public interface ITablesService
{
    Task<Table?> GetTable(int id);
    Task<IReadOnlyCollection<Table>> GetAllTables();
    Task<Table> AddTable(Table table);
    Task UpdateTable(Table table);
    Task DeleteTable(int id);
}