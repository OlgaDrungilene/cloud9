namespace backend.DTOs;

public class OrderResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; } =default!;
    public DateTime CreatedAt { get; set; }
    public string Status { get; set; } = default!;
    public decimal TotalAmount { get; set; }
}