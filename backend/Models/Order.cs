namespace backend.Models;

public class Order 
{
    public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}