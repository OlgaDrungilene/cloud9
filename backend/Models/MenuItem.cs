namespace backend.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Description { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;

    public bool IsSpecial { get; set; } = false;
    public DateTime? SpecialDate { get; set; }
}
