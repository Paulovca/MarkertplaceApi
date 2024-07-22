using System.ComponentModel.DataAnnotations;

namespace MarkertplaceApi.Models.Validations;

public class Item_EnsurePositiveValueQuantityAvailableAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var item = validationContext.ObjectInstance as Item;
        
        if (int.IsNegative(item.QuantityAvailable))
        {
            return new ValidationResult("For quantity available, the value must be greater than 0.");
        }
        
        if (item.QuantityAvailable >= int.MaxValue)
        {
            return new ValidationResult("For quantity available, the value exceeded the limit.");
        }
        
        return ValidationResult.Success;
    }
}