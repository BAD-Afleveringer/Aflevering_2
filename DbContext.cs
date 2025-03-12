using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;

public class ExperienceDbContext : DbContext
{
    public ExperienceDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<SharedExperience> SharedExperiences { get; set; }


}


