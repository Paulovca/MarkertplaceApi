using System.ComponentModel.DataAnnotations;
using MarkertplaceApi.Models.Validations;

namespace MarkertplaceApi.Models;

public class Item
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Item_EnsurePositiveValuePrice]
    public double Price { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Item_EnsurePositiveValueQuantityAvailable]
    public int QuantityAvailable { get; set; }
}