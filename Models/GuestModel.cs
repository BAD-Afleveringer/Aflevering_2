using System.ComponentModel.DataAnnotations;

namespace Aflevering_2.Models;

public class Guest
{
    public int GuestId { get; set; }
    [Required]
    public int GuestAge { get; set; }
    [Required]
    public string? GuestNumber { get; set; }
    [Required]
    public string? GuestName { get; set; }
    public ICollection<SharedExperience>? SharedExperiences { get; set; }

}

