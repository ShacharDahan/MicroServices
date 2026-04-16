using Entities.DataTransferObjects;
using Interfaces;
using Models;

namespace Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _repository;

    public ItemService(IItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Item>> GetThreeRandomItems()
    {
        var items = await _repository.GetAllAsync();
        return items.OrderBy(_ => Guid.NewGuid()).Take(3).ToList();
    }

    public async Task<Item> GetSpecificItem(Guid guid) => await _repository.GetByIdAsync(guid);

    public async Task<Item> CreateItem(CreateItemDto item)
    {
        var newItem = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = item.Name,
            Price = item.Price,
            Description = item.Description,
            CreatedDate = DateTime.Now,
        };
        await _repository.CreateAsync(newItem);
        return newItem;
    }

    public async Task UpdateItem(Item existingItem, UpdateItemDto updatedItem)
    {
        existingItem.Name = updatedItem.Name ?? existingItem.Name;
        existingItem.Description = updatedItem.Description ?? existingItem.Description;
        existingItem.Price = updatedItem.Price ?? existingItem.Price;

        await _repository.UpdateAsync(existingItem.ItemId, existingItem);
    }

    public async Task RemoveItem(Guid id) => await _repository.RemoveAsync(id);
}
