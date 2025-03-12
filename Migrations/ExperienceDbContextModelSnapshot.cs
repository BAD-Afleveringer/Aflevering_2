﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aflevering_2.Migrations
{
    [DbContext(typeof(ExperienceDbContext))]
    partial class ExperienceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("GuestNumber")
                        .HasColumnType("int");

                    b.HasKey("GuestId");

                    b.ToTable("Guests");
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

                    b.Property<int>("CVR")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
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
