using System.ComponentModel.DataAnnotations;

namespace Aflevering_2.Models;

public class Provider
{
    public int ProviderId { get; set; }
    [Required]
    public byte[]? TouristicOperatorPermitPdf { get; set; }

    [Required]
    public string? Address { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
    public ICollection<Experience>? Experiences { get; set; }
}


// used to create provider without experience or shared experience
public class CreateProviderDTO
{
    [Required]
    public byte[]? TouristicOperatorPermitPdf { get; set; }
    [Required]
    public string? Address { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
}