﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aflevering_2.Migrations
{
    [DbContext(typeof(ExperienceDbContext))]
    [Migration("20250319133649_Migration3")]
    partial class Migration3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aflevering_2.Models.Discount", b =>
                {
                    b.Property<int>("DiscountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountID"));

                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("discountPercentage")
                        .HasColumnType("int");

                    b.Property<int>("minGuests")
                        .HasColumnType("int");

                    b.HasKey("DiscountID");

                    b.HasIndex("ExperienceId");

                    b.ToTable("Discounts");

                    b.HasData(
                        new
                        {
                            DiscountID = 1,
                            ExperienceId = 1,
                            discountPercentage = 10,
                            minGuests = 4
                        },
                        new
                        {
                            DiscountID = 2,
                            ExperienceId = 6,
                            discountPercentage = 15,
                            minGuests = 3
                        });
                });

            modelBuilder.Entity("Aflevering_2.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExperienceId"));

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProviderId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienceId");

                    b.HasIndex("ProviderId");

                    b.ToTable("Experiences");

                    b.HasData(
                        new
                        {
                            ExperienceId = 1,
                            Price = 350,
                            ProviderId = 1,
                            Title = "Kayaking"
                        },
                        new
                        {
                            ExperienceId = 2,
                            Price = 450,
                            ProviderId = 2,
                            Title = "food"
                        },
                        new
                        {
                            ExperienceId = 3,
                            Price = 600,
                            ProviderId = 3,
                            Title = "Wine tasting"
                        },
                        new
                        {
                            ExperienceId = 4,
                            Price = 275,
                            ProviderId = 4,
                            Title = "Guided City Tour"
                        },
                        new
                        {
                            ExperienceId = 5,
                            Price = 220,
                            ProviderId = 2,
                            Title = "Fredagsbar"
                        },
                        new
                        {
                            ExperienceId = 6,
                            Price = 750,
                            ProviderId = 2,
                            Title = "Paragliding"
                        },
                        new
                        {
                            ExperienceId = 7,
                            Price = 525,
                            ProviderId = 3,
                            Title = "Diving"
                        });
                });

            modelBuilder.Entity("Aflevering_2.Models.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuestId"));

                    b.Property<int>("GuestAge")
                        .HasColumnType("int");

                    b.Property<string>("GuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GuestNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuestId");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            GuestId = 1,
                            GuestAge = 32,
                            GuestName = "Michael Jensen",
                            GuestNumber = "+4534567890"
                        },
                        new
                        {
                            GuestId = 2,
                            GuestAge = 27,
                            GuestName = "Sofie Rasmussen",
                            GuestNumber = "+4554460788"
                        },
                        new
                        {
                            GuestId = 3,
                            GuestAge = 34,
                            GuestName = "Emil Kristensen",
                            GuestNumber = "+4567890123"
                        },
                        new
                        {
                            GuestId = 4,
                            GuestAge = 29,
                            GuestName = "Lotte Mikkelsen",
                            GuestNumber = "+4545678901"
                        });
                });

            modelBuilder.Entity("Aflevering_2.Models.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProviderId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("TouristicOperatorPermitPdf")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");

                    b.HasData(
                        new
                        {
                            ProviderId = 1,
                            Address = "Sunset Boulevard 21B, 8000",
                            PhoneNumber = "+4543219876",
                            TouristicOperatorPermitPdf = new byte[] { 1, 2, 5, 4, 5 }
                        },
                        new
                        {
                            ProviderId = 2,
                            Address = "Lakeside Road 8, 5000",
                            PhoneNumber = "+4578945632",
                            TouristicOperatorPermitPdf = new byte[] { 1, 4, 3, 4, 5 }
                        },
                        new
                        {
                            ProviderId = 3,
                            Address = "Mountain View 12, 3400",
                            PhoneNumber = "+4598765432",
                            TouristicOperatorPermitPdf = new byte[] { 2, 3, 3, 4, 5 }
                        },
                        new
                        {
                            ProviderId = 4,
                            Address = "Coastal Lane 5A, 6000",
                            PhoneNumber = "+4543219876",
                            TouristicOperatorPermitPdf = new byte[] { 1, 2, 3, 4, 5 }
                        });
                });

            modelBuilder.Entity("Aflevering_2.Models.SharedExperience", b =>
                {
                    b.Property<int>("SharedExperienceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SharedExperienceId"));

                    b.Property<DateTime>("SE_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("SE_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SharedExperienceId");

                    b.ToTable("SharedExperiences");

                    b.HasData(
                        new
                        {
                            SharedExperienceId = 1,
                            SE_Date = new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SE_Title = "Summer Adventure in Aarhus"
                        },
                        new
                        {
                            SharedExperienceId = 2,
                            SE_Date = new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SE_Title = "Fun stuff in København"
                        },
                        new
                        {
                            SharedExperienceId = 3,
                            SE_Date = new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SE_Title = "Relaxing in Odense"
                        },
                        new
                        {
                            SharedExperienceId = 4,
                            SE_Date = new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SE_Title = "Family Getaway in Padborg"
                        });
                });

            modelBuilder.Entity("ExperienceSharedExperience", b =>
                {
                    b.Property<int>("ExperiencesExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("SharedExperiencesSharedExperienceId")
                        .HasColumnType("int");

                    b.HasKey("ExperiencesExperienceId", "SharedExperiencesSharedExperienceId");

                    b.HasIndex("SharedExperiencesSharedExperienceId");

                    b.ToTable("ExperienceSharedExperience");

                    b.HasData(
                        new
                        {
                            ExperiencesExperienceId = 1,
                            SharedExperiencesSharedExperienceId = 1
                        },
                        new
                        {
                            ExperiencesExperienceId = 2,
                            SharedExperiencesSharedExperienceId = 1
                        },
                        new
                        {
                            ExperiencesExperienceId = 2,
                            SharedExperiencesSharedExperienceId = 2
                        });
                });

            modelBuilder.Entity("GuestSharedExperience", b =>
                {
                    b.Property<int>("GuestsGuestId")
                        .HasColumnType("int");

                    b.Property<int>("SharedExperiencesSharedExperienceId")
                        .HasColumnType("int");

                    b.HasKey("GuestsGuestId", "SharedExperiencesSharedExperienceId");

                    b.HasIndex("SharedExperiencesSharedExperienceId");

                    b.ToTable("GuestSharedExperience");

                    b.HasData(
                        new
                        {
                            GuestsGuestId = 1,
                            SharedExperiencesSharedExperienceId = 1
                        },
                        new
                        {
                            GuestsGuestId = 2,
                            SharedExperiencesSharedExperienceId = 1
                        },
                        new
                        {
                            GuestsGuestId = 2,
                            SharedExperiencesSharedExperienceId = 2
                        });
                });

            modelBuilder.Entity("Aflevering_2.Models.Discount", b =>
                {
                    b.HasOne("Aflevering_2.Models.Experience", null)
                        .WithMany("Discounts")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aflevering_2.Models.Experience", b =>
                {
                    b.HasOne("Aflevering_2.Models.Provider", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExperienceSharedExperience", b =>
                {
                    b.HasOne("Aflevering_2.Models.Experience", null)
                        .WithMany()
                        .HasForeignKey("ExperiencesExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aflevering_2.Models.SharedExperience", null)
                        .WithMany()
                        .HasForeignKey("SharedExperiencesSharedExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GuestSharedExperience", b =>
                {
                    b.HasOne("Aflevering_2.Models.Guest", null)
                        .WithMany()
                        .HasForeignKey("GuestsGuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aflevering_2.Models.SharedExperience", null)
                        .WithMany()
                        .HasForeignKey("SharedExperiencesSharedExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aflevering_2.Models.Experience", b =>
                {
                    b.Navigation("Discounts");
                });

            modelBuilder.Entity("Aflevering_2.Models.Provider", b =>
                {
                    b.Navigation("Experiences");
                });
#pragma warning restore 612, 618
        }
    }
}
