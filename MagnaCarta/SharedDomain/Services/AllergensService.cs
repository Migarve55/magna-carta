using SharedDomain.Entities;
using SharedDomain.Repositories;

namespace SharedDomain.Services;

public class AllergensService : IAllergensService
{
    private readonly IRepository<Allergen> _repository;

    public AllergensService(IRepository<Allergen> repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Allergen>> GetAllAllergens()
    {
        return await _repository.GetAllAsync();
    }
}