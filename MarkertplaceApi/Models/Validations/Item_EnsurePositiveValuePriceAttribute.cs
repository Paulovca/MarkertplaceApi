using System.ComponentModel.DataAnnotations;

namespace MarkertplaceApi.Models.Validations;

public class Item_EnsurePositiveValuePriceAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var item = validationContext.ObjectInstance as Item;

        if (item.Price < double.Epsilon)
        {
            return new ValidationResult("For pricing items, the value must be greater than 0.");
        }
        
        if (item.Price >= double.MaxValue)
        {
            return new ValidationResult("For pricing items, the value exceeded the limit.");
        }
        
        return ValidationResult.Success;
    }
}