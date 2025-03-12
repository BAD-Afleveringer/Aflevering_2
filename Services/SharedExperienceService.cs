using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;
using Aflevering_2;

namespace Aflevering_2.Services;

public class SharedExperienceService : GenericService<SharedExperience>
{
    public SharedExperienceService(ExperienceDbContext context) : base(context) { }
}