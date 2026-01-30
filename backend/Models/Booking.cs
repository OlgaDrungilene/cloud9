using System.ComponentModel.DataAnnotations;
namespace backend.Models;

public class Booking
{
     public int Id { get; set; }

    [Required]
    public string FullName { get; set; } = default!;

    [Required, EmailAddress]
    public string Email { get; set; } = default!;

    [Required, Phone]
    public string Phone { get; set; } = default!;

    [Required]
    public DateTime BookingTime { get; set; }

    [Range(1, 20)]
    public int Persons { get; set; }

    public string? Notes { get; set; } // allergier, önskemål, osv

    public int? TableId { get; set; }
    public Table? Table { get; set; }
}