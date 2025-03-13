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

    ExperienceDbContext _context;
    // Seeding database



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Provider>().HasData(
            new Provider
            {
                CVR = 45987632,
                Address = "Sunset Boulevard 21B, 8000",
                PhoneNumber = "+45 43219876",
            },
            new Provider
            {
                CVR = 87542319,
                Address = "Lakeside Road 8, 5000",
                PhoneNumber = "+4578945632"
            },
            new Provider
            {
                CVR = 65498731,
                Address = "Mountain View 12, 3400",
                PhoneNumber = "+4598765432"
            },
            new Provider
            {
                CVR = 32145698,
                Address = "Coastal Lane 5A, 6000",
                PhoneNumber = "+4543219876"
            }
        );


        modelBuilder.Entity<Experience>().HasData(
        new Experience
        {
            Title = "Kayaking",
            Price = 350,
            ProviderId = 1,
        },

        new Experience
        {
            Title = "food",
            Price = 450,
            ProviderId = 2,
        },

        new Experience
        {
            Title = "Wine tasting",
            Price = 600,
            ProviderId = 3,
        },

        new Experience
        {
            Title = "Guided City Tour",
            Price = 275,
            ProviderId = 4,
        },

        new Experience
        {
            Title = "Fredagsbar",
            Price = 220,
            ProviderId = 2,
        },

        new Experience
        {
            Title = "Paragliding",
            Price = 750,
            ProviderId = 2,
        },

        new Experience
        {
            Title = "Diving",
            Price = 525,
            ProviderId = 3,
        }

    );


        modelBuilder.Entity<SharedExperience>().HasData(
            new SharedExperience
            {
                SE_Title = "Summer Adventure in Aarhus",
                SE_Date = new DateTime(2025, 06, 18)
            },
            new SharedExperience
            {
                SE_Title = "Fun stuff in København",
                SE_Date = new DateTime(2025, 07, 29)
            },
            new SharedExperience
            {
                SE_Title = "Relaxing in Odense",
                SE_Date = new DateTime(2025, 07, 10)
            },
            new SharedExperience
            {
                SE_Title = "Family Getaway in Padborg",
                SE_Date = new DateTime(2025, 06, 25)
            }
        );


        modelBuilder.Entity<Guest>().HasData(
            new Guest
            {
                GuestName = "Michael Jensen",
                GuestAge = 32,
                GuestNumber = "+4534567890"
            },
            new Guest
            {
                GuestName = "Sofie Rasmussen",
                GuestAge = 27
            },
            new Guest
            {
                GuestName = "Emil Kristensen",
                GuestAge = 34,
                GuestNumber = "+4567890123"
            },
            new Guest
            {
                GuestName = "Lotte Mikkelsen",
                GuestAge = 29,
                GuestNumber = "+4545678901"
            }
        );



        modelBuilder.Entity<Discount>().HasData(
            new Discount
            {
                minGuests = 4,
                discountPercentage = 10,
                ExperienceId = 1
            },
            new Discount
            {
                minGuests = 3,
                discountPercentage = 15,
                ExperienceId = 6
            }
        );

        // Seed junction table between experience and sharedexperience
        modelBuilder.Entity<Experience>()
            .HasMany(e => e.SharedExperiences)
            .WithMany(se => se.Experiences)
            .UsingEntity(j => j.HasData(
                new { ExperiencesExperienceId = 1, SharedExperiencesSharedExperienceId = 1 },
                new { ExperiencesExperienceId = 2, SharedExperiencesSharedExperienceId = 1 },
                new { ExperiencesExperienceId = 2, SharedExperiencesSharedExperienceId = 2 }
            ));

        modelBuilder.Entity<Guest>()
            .HasMany(g => g.SharedExperiences)
            .WithMany(se => se.Guests)
            .UsingEntity(j => j.HasData(
                new { GuestsGuestId = 1, SharedExperiencesSharedExperienceId = 1 },
                new { GuestsGuestId = 2, SharedExperiencesSharedExperienceId = 1 },
                new { GuestsGuestId = 2, SharedExperiencesSharedExperienceId = 2 }
            ));

    }
}


