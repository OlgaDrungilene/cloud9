using System.ComponentModel.DataAnnotations;
namespace backend.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = default!;
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; } = default!;

    [Range(1, 100)]
    public int Quantity { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "UnitPrice must be at least 0.01")]
    public decimal UnitPrice { get; set; }
}