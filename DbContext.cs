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


    // Seeding database
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Provider>().HasData(
            new Provider
            {
                // setting id's really doesnt matter because the chosen id will be overwritten when seeded to the database,
                // with the correct value according to it being identity and primary key. It is required though.
                ProviderId = 1,
                TouristicOperatorPermitPdf = new byte[] {1,2,5,4,5},
                Address = "Sunset Boulevard 21B, 8000",
                PhoneNumber = "+4543219876",
            },
            new Provider
            {
                ProviderId = 2,
                TouristicOperatorPermitPdf = new byte[] {1,4,3,4,5},
                Address = "Lakeside Road 8, 5000",
                PhoneNumber = "+4578945632"
            },
            new Provider
            {
                ProviderId = 3,
                TouristicOperatorPermitPdf = new byte[] {2,3,3,4,5},
                Address = "Mountain View 12, 3400",
                PhoneNumber = "+4598765432"
            },
            new Provider
            {
                ProviderId = 4,
                TouristicOperatorPermitPdf = new byte[] {1,2,3,4,5},
                Address = "Coastal Lane 5A, 6000",
                PhoneNumber = "+4543219876"
            }
        );


        modelBuilder.Entity<Experience>().HasData(
        new Experience
        {
            ExperienceId = 1,
            Title = "Kayaking",
            Price = 350,
            ProviderId = 1,
        },

        new Experience
        {
            ExperienceId = 2,
            Title = "food",
            Price = 450,
            ProviderId = 2,
        },

        new Experience
        {
            ExperienceId = 3,
            Title = "Wine tasting",
            Price = 600,
            ProviderId = 3,
        },

        new Experience
        {
            ExperienceId = 4,
            Title = "Guided City Tour",
            Price = 275,
            ProviderId = 4,
        },

        new Experience
        {
            ExperienceId = 5,
            Title = "Fredagsbar",
            Price = 220,
            ProviderId = 2,
        },

        new Experience
        {
            ExperienceId = 6,
            Title = "Paragliding",
            Price = 750,
            ProviderId = 2,
        },

        new Experience
        {
            ExperienceId = 7,
            Title = "Diving",
            Price = 525,
            ProviderId = 3,
        }

    );


        modelBuilder.Entity<SharedExperience>().HasData(
            new SharedExperience
            {
                SharedExperienceId = 1,
                SE_Title = "Summer Adventure in Aarhus",
                SE_Date = new DateTime(2025, 06, 18)
            },
            new SharedExperience
            {
                SharedExperienceId = 2,
                SE_Title = "Fun stuff in København",
                SE_Date = new DateTime(2025, 07, 29)
            },
            new SharedExperience
            {
                SharedExperienceId = 3,
                SE_Title = "Relaxing in Odense",
                SE_Date = new DateTime(2025, 07, 10)
            },
            new SharedExperience
            {
                SharedExperienceId = 4,
                SE_Title = "Family Getaway in Padborg",
                SE_Date = new DateTime(2025, 06, 25)
            }
        );


        modelBuilder.Entity<Guest>().HasData(
            new Guest
            {
                GuestId = 1,
                GuestName = "Michael Jensen",
                GuestAge = 32,
                GuestNumber = "+4534567890"
            },
            new Guest
            {
                GuestId = 2,
                GuestName = "Sofie Rasmussen",
                GuestAge = 27,
                GuestNumber = "+4554460788"
            },
            new Guest
            {
                GuestId = 3,
                GuestName = "Emil Kristensen",
                GuestAge = 34,
                GuestNumber = "+4567890123"
            },
            new Guest
            {
                GuestId = 4,
                GuestName = "Lotte Mikkelsen",
                GuestAge = 29,
                GuestNumber = "+4545678901"
            }
        );



        modelBuilder.Entity<Discount>().HasData(
            new Discount
            {
                DiscountID = 1,
                minGuests = 4,
                discountPercentage = 10,
                ExperienceId = 1
            },
            new Discount
            {
                DiscountID = 2,
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


