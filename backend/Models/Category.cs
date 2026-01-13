namespace backend.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // Navigation
    public List<MenuItem> MenuItems { get; set; } = new();
}
