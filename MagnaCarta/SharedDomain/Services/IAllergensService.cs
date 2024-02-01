using SharedDomain.Entities;

namespace SharedDomain.Services;

public interface IAllergensService
{
    Task<IReadOnlyCollection<Allergen>> GetAllAllergens();
}