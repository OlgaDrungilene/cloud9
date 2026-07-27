using System.ComponentModel.DataAnnotations;
namespace backend.DTOs;

public class CreateCategoryDto
{ 

    [Required]
    public string Name { get; set; } = default!;
}