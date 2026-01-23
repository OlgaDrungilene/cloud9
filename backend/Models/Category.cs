using System.Text.Json.Serialization;

namespace backend.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    [JsonIgnore]
    public List<MenuItem> MenuItems { get; set; } = new();
}
