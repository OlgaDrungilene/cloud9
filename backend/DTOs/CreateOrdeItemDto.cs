using System.ComponentModel.DataAnnotations;
namespace backend.DTOs;

public class CreateOrderItemDto
{
    [Range(1, int.MaxValue, ErrorMessage = "Please select a valid menu item.")]
    public int MenuItemId { get; set; }
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100.")]
    public int Quantity { get; set; }
}