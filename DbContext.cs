using Microsoft.EntityFrameworkCore;

public class ExperienceDbContext : DbContext
{
    public ExperienceDbContext(DbContextOptions options) : base(options) { }


}