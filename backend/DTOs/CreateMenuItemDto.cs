using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;


public class CreateMenuItemDto
{
    [Required]
    public string Name { get; set; } = default!;
    
    [Required][Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Tags { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be greater than 0")]
    public int CategoryId { get; set; }
    public bool IsSpecial { get; set; }
    public string? ImageUrl { get; set; }
}