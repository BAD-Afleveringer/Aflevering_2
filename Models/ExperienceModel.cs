using System.ComponentModel.DataAnnotations;

namespace Aflevering_2.Models;

// data representation

public class Experience  // representation of table
{
    public int ExperienceId { get; set; }

    [Required]
    public string? Title { get; set; }

    [Required]
    public int Price { get; set; } // ? = allow nulls
    public int ProviderId { get; set; }

    public ICollection<Discount>? Discounts { get; set; }
}
