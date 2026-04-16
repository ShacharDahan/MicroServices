using Exceptions;
using Interfaces;
using Models;
using MongoDB.Driver;

namespace Repository;

public class ItemRepository : IItemRepository
{
    private readonly IMongoCollection<Item> _collection;

    public ItemRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Item>("items");
    }

    public async Task<List<Item>> GetAllAsync() => await _collection.Find(_ => true).ToListAsync();

    public async Task<Item> GetByIdAsync(Guid id)
    {
        var item = await _collection.Find(i => i.ItemId == id).FirstOrDefaultAsync();

        if (item == null)
        {
            throw new ItemNotFoundException(id);
        }

        return item;
    }

    public async Task CreateAsync(Item item) => await _collection.InsertOneAsync(item);

    public async Task UpdateAsync(Guid id, Item updated) =>
        await _collection.ReplaceOneAsync(i => i.ItemId == id, updated);

    public async Task RemoveAsync(Guid id) => await _collection.DeleteOneAsync(i => i.ItemId == id);
}
