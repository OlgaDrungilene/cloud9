
using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class CreateOrderDto
{
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = default!;

[MinLength(1, ErrorMessage = "Order must contain at least one item.")]
    public List<CreateOrderItemDto> OrderItems { get; set; } = new();
}
