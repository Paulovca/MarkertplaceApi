using MarkertplaceApi.Data;
using MarkertplaceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MarkertplaceApi.Filters;

public class Item_ValidateCreateItemFilterAttribute : ActionFilterAttribute
{
    private readonly ApplicationDbContext db;

    public Item_ValidateCreateItemFilterAttribute(ApplicationDbContext db)
    {
        this.db = db;
    }
    
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var item = context.ActionArguments["item"] as Item;

        if (item == null)
        {
            context.ModelState.AddModelError("Item", "Item object is null.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
        else
        {
            var existingItem = db.Items.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(item.Name) &&
                !string.IsNullOrWhiteSpace(x.Name) &&
                x.Name.ToLower() == item.Name.ToLower() &&
                !string.IsNullOrWhiteSpace(item.Description) &&
                !string.IsNullOrWhiteSpace(x.Description) &&
                x.Description.ToLower() == item.Description.ToLower());

            if (existingItem != null)
            {
                context.ModelState.AddModelError("Item", "Item already exists.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}