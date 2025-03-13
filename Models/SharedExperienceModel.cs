using System.ComponentModel.DataAnnotations;

namespace Aflevering_2.Models;

public class SharedExperience
{

    public int SharedExperienceId { get; set; }
    [Required]
    public string? SE_Title { get; set; }

    [Required]
    public DateTime SE_Date { get; set; }
    public ICollection<Guest>? Guests { get; set; }
    public ICollection<Experience>? Experiences { get; set; }
}