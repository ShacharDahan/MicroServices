using Entities.DataTransferObjects;
using Models;

namespace Interfaces;

public interface IItemService
{
    Task<List<Item>> GetThreeRandomItems();
    Task<Item> GetSpecificItem(Guid id);
    Task<Item> CreateItem(CreateItemDto item);
    Task UpdateItem(Item existingItem, UpdateItemDto updatedItem);
    Task RemoveItem(Guid id);
}
