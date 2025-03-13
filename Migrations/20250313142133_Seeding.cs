using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aflevering_2.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Providers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "GuestNumber",
                table: "Guests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "GuestId", "GuestAge", "GuestName", "GuestNumber" },
                values: new object[,]
                {
                    { 1, 32, "Michael Jensen", "+4534567890" },
                    { 2, 27, "Sofie Rasmussen", "+4554460788" },
                    { 3, 34, "Emil Kristensen", "+4567890123" },
                    { 4, 29, "Lotte Mikkelsen", "+4545678901" }
                });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "ProviderId", "Address", "CVR", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Sunset Boulevard 21B, 8000", 45987632, "+4543219876" },
                    { 2, "Lakeside Road 8, 5000", 87542319, "+4578945632" },
                    { 3, "Mountain View 12, 3400", 65498731, "+4598765432" },
                    { 4, "Coastal Lane 5A, 6000", 32145698, "+4543219876" }
                });

            migrationBuilder.InsertData(
                table: "SharedExperiences",
                columns: new[] { "SharedExperienceId", "SE_Date", "SE_Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Summer Adventure in Aarhus" },
                    { 2, new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fun stuff in København" },
                    { 3, new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Relaxing in Odense" },
                    { 4, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Family Getaway in Padborg" }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "ExperienceId", "Price", "ProviderId", "Title" },
                values: new object[,]
                {
                    { 1, 350.0, 1, "Kayaking" },
                    { 2, 450.0, 2, "food" },
                    { 3, 600.0, 3, "Wine tasting" },
                    { 4, 275.0, 4, "Guided City Tour" },
                    { 5, 220.0, 2, "Fredagsbar" },
                    { 6, 750.0, 2, "Paragliding" },
                    { 7, 525.0, 3, "Diving" }
                });

            migrationBuilder.InsertData(
                table: "GuestSharedExperience",
                columns: new[] { "GuestsGuestId", "SharedExperiencesSharedExperienceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "DiscountID", "ExperienceId", "discountPercentage", "minGuests" },
                values: new object[,]
                {
                    { 1, 1, 10, 4 },
                    { 2, 6, 15, 3 }
                });

            migrationBuilder.InsertData(
                table: "ExperienceSharedExperience",
                columns: new[] { "ExperiencesExperienceId", "SharedExperiencesSharedExperienceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "DiscountID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "DiscountID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExperienceSharedExperience",
                keyColumns: new[] { "ExperiencesExperienceId", "SharedExperiencesSharedExperienceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ExperienceSharedExperience",
                keyColumns: new[] { "ExperiencesExperienceId", "SharedExperiencesSharedExperienceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ExperienceSharedExperience",
                keyColumns: new[] { "ExperiencesExperienceId", "SharedExperiencesSharedExperienceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "GuestSharedExperience",
                keyColumns: new[] { "GuestsGuestId", "SharedExperiencesSharedExperienceId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GuestSharedExperience",
                keyColumns: new[] { "GuestsGuestId", "SharedExperiencesSharedExperienceId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GuestSharedExperience",
                keyColumns: new[] { "GuestsGuestId", "SharedExperiencesSharedExperienceId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SharedExperiences",
                keyColumn: "SharedExperienceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SharedExperiences",
                keyColumn: "SharedExperienceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Guests",
                keyColumn: "GuestId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SharedExperiences",
                keyColumn: "SharedExperienceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SharedExperiences",
                keyColumn: "SharedExperienceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Providers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "GuestNumber",
                table: "Guests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
