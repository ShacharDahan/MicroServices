using Models;

namespace Interfaces;

public interface IItemRepository
{
    Task<List<Item>> GetAllAsync();
    Task<Item> GetByIdAsync(Guid id);
    Task CreateAsync(Item item);
    Task UpdateAsync(Guid id, Item updated);
    Task RemoveAsync(Guid id);
}
