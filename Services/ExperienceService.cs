using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;

namespace Aflevering_2.Services;

public class ExperienceService : GenericService<Experience>
{
    public ExperienceService(ExperienceDbContext context) : base(context) { }
}