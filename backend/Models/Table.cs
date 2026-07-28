using System.Text.Json.Serialization;
namespace backend.Models;

public class Table
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public bool IsAvailable { get; set; }

    public bool IsActive { get; set; }= true;

    [JsonIgnore]
    public ICollection<Booking>? Bookings { get; set; }
}
