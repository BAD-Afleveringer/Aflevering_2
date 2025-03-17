using System.ComponentModel.DataAnnotations;

namespace Aflevering_2.Models;

public class Discount
{
    // ID
    public int DiscountID { get; set; }
    // minGuests
    [Required]
    public int minGuests { get; set; }
    // discountPercentage
    public int discountPercentage { get; set; }
    // ExperienceID
    public int ExperienceId { get; set; }
}

public class DiscountDTO
{
    // minGuests
    [Required]
    public int minGuests { get; set; }
    // discountPercentage
    public int discountPercentage { get; set; }
    // ExperienceID
    public int ExperienceId { get; set; }
}