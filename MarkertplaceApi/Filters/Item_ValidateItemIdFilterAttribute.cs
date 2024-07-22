using MarkertplaceApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MarkertplaceApi.Filters;

public class Item_ValidateItemIdFilterAttribute : ActionFilterAttribute
{
    private readonly ApplicationDbContext db;

    public Item_ValidateItemIdFilterAttribute(ApplicationDbContext db)
    {
        this.db = db;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var itemId = context.ActionArguments["id"] as int?;
        if (itemId.HasValue)
        {
            if (itemId.Value <= 0)
            {
                context.ModelState.AddModelError("ItemId", "ItemId is invalid.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else 
            {
                var item = db.Items.Find(itemId.Value);

                if (item == null)
                {
                    context.ModelState.AddModelError("ItemId", "Item doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
                else
                {
                    context.HttpContext.Items["item"] = item;
                }
            }
        }
    }
}