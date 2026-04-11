using MicroServices.ActionFilters;
using Microsoft.AspNetCore.Mvc;

[Route("api/items")]
[ApiController]
public class ItemController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetThreeRandoms()
    {
        // TODO: functionallity
        return Ok();
    }

    [HttpGet("{id:guid}", Name = "GetItemById")]
    public async Task<IActionResult> GetItemById()
    {
        return Ok("item");
    }

    [HttpPost] //Add validations
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> AddNewItem([FromBody] CreateItemDto item)
    {
        return Ok("Added item");
    }

    [HttpPut] //Add validations
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateItem([FromBody] UpdateItemDto item)
    {
        return Ok("Updated item");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteItem()
    {
        return Ok("Deleted item");
    }
}
