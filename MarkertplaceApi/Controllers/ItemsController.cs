using MarkertplaceApi.Attributes;
using MarkertplaceApi.Data;
using MarkertplaceApi.Filters;
using MarkertplaceApi.Filters.AuthFilters;
using MarkertplaceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarkertplaceApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[JwtTokenAuthFilter]
public class ItemsController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public ItemsController(ApplicationDbContext db)
    {
        this._db = db;
    }
    
    [HttpGet]
    [RequiredClaim("read", "true")]
    public IActionResult GetItems()
    {
        return Ok(_db.Items.ToList());
    }
    
    [HttpGet("{id}")]
    [TypeFilter(typeof(Item_ValidateItemIdFilterAttribute))]
    [RequiredClaim("read", "true")]
    public IActionResult GetItemById(int id)
    {
        return Ok(HttpContext.Items["item"]);
    }
    
    [HttpPost]
    [TypeFilter(typeof(Item_ValidateCreateItemFilterAttribute))]
    [RequiredClaim("write", "true")]
    public IActionResult CreateItem(Item item)
    {
        this._db.Items.Add(item);
        this._db.SaveChanges();

        return CreatedAtAction(nameof(GetItemById),
            new { id = item.Id },
            item);
    }
    
    [HttpPut("{id}")]
    [TypeFilter(typeof(Item_ValidateItemIdFilterAttribute))]
    [TypeFilter(typeof(Item_ValidateUpdateItemFilterAttribute))]
    [RequiredClaim("write", "true")]
    public IActionResult UpdateItem(int id, Item item)
    {
        var itemToUpdate = HttpContext.Items["item"] as Item;
        itemToUpdate.Name = item.Name;
        itemToUpdate.Description = item.Description;
        itemToUpdate.QuantityAvailable = item.QuantityAvailable;
        itemToUpdate.Price = item.Price;
        
        _db.SaveChanges();
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [TypeFilter(typeof(Item_ValidateItemIdFilterAttribute))]
    [RequiredClaim("delete", "true")]
    public IActionResult DeleteItem(int id)
    {
        var itemToDelete = HttpContext.Items["item"] as Item;

        _db.Items.Remove(itemToDelete);
        _db.SaveChanges();

        return Ok(itemToDelete);
    }
}