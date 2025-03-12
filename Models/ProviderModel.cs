using System.ComponentModel.DataAnnotations;

namespace Aflevering_2.Models;

public class Provider
{
    public int ProviderId { get; set; }
    [Required]
    public int CVR { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public int PhoneNumber { get; set; }
    public ICollection<Experience>? Experiences { get; set; }
}