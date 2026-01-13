namespace backend.Models;

public class Booking
{
     public int Id { get; set; }
    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;

    public DateTime Date { get; set; }
    public int Guests { get; set; }

    // nullable → om bord ej tilldelat ännu
    public int? TableId { get; set; }
    public Table? Table { get; set; }
    public string? Notes { get; set; } // allergier, önskemål, osv
}
