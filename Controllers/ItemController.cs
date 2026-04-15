using Entities.DataTransferObjects;
using MicroServices.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Services;

[Route("api/items")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly ItemService _itemService;

    public ItemController(ItemService itemService)
    {
        this._itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetThreeRandoms()
    {
        var items = await _itemService.GetThreeRandomItems();

        return Ok(items);
    }

    [HttpGet("{id:guid}", Name = "GetItemById")]
    public async Task<IActionResult> GetItemById(Guid id)
    {
        var item = await _itemService.GetSpecificItem(id);
        return Ok(item);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> AddNewItem([FromBody] CreateItemDto item)
    {
        var newItem = await _itemService.CreateItem(item);

        return CreatedAtRoute("GetItemById", new { id = newItem.ItemId }, newItem);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] UpdateItemDto updateItem)
    {
        var existingItem = await _itemService.GetSpecificItem(id);
        await _itemService.UpdateItem(existingItem, updateItem);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteItem(Guid id)
    {
        await _itemService.RemoveItem(id);

        return NoContent();
    }
}
