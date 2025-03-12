using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;
using Aflevering_2;

namespace Aflevering_2.Services;

public class ProviderService : GenericService<Provider>
{
    public ProviderService(ExperienceDbContext context) : base(context) { }



}

