using MarkertplaceApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MarkertplaceApi.Filters;

public class Item_ValidateUpdateItemFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        var id = context.ActionArguments["id"] as int?;
        var item = context.ActionArguments["item"] as Item;

        if (id.HasValue && item != null && id != item.Id)
        {
            context.ModelState.AddModelError("ItemId", "ItemId is not the same as id.");
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            context.Result = new BadRequestObjectResult(problemDetails);
        }
    }
}