using System.Text.Json.Serialization;
namespace backend.Models;

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public string? Tags {get; set; }

    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category Category { get; set; } = default!;

    public bool IsSpecial { get; set; } = false;
    public DateTime? SpecialDate { get; set; }
    public string? ImageUrl {get; set; }
}
