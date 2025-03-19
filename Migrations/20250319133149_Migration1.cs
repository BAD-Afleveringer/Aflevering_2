using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aflevering_2.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuestAge = table.Column<int>(type: "int", nullable: false),
                    GuestNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuestName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVR = table.Column<int>(type: "int", nullable: false),
                    TouristicOperatorPermitPdf = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                });

            migrationBuilder.CreateTable(
                name: "SharedExperiences",
                columns: table => new
                {
                    SharedExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SE_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SE_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedExperiences", x => x.SharedExperienceId);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceId);
                    table.ForeignKey(
                        name: "FK_Experiences_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestSharedExperience",
                columns: table => new
                {
                    GuestsGuestId = table.Column<int>(type: "int", nullable: false),
                    SharedExperiencesSharedExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestSharedExperience", x => new { x.GuestsGuestId, x.SharedExperiencesSharedExperienceId });
                    table.ForeignKey(
                        name: "FK_GuestSharedExperience_Guests_GuestsGuestId",
                        column: x => x.GuestsGuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestSharedExperience_SharedExperiences_SharedExperiencesSharedExperienceId",
                        column: x => x.SharedExperiencesSharedExperienceId,
                        principalTable: "SharedExperiences",
                        principalColumn: "SharedExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    minGuests = table.Column<int>(type: "int", nullable: false),
                    discountPercentage = table.Column<int>(type: "int", nullable: false),
                    ExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountID);
                    table.ForeignKey(
                        name: "FK_Discounts_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceSharedExperience",
                columns: table => new
                {
                    ExperiencesExperienceId = table.Column<int>(type: "int", nullable: false),
                    SharedExperiencesSharedExperienceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceSharedExperience", x => new { x.ExperiencesExperienceId, x.SharedExperiencesSharedExperienceId });
                    table.ForeignKey(
                        name: "FK_ExperienceSharedExperience_Experiences_ExperiencesExperienceId",
                        column: x => x.ExperiencesExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "ExperienceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceSharedExperience_SharedExperiences_SharedExperiencesSharedExperienceId",
                        column: x => x.SharedExperiencesSharedExperienceId,
                        principalTable: "SharedExperiences",
                        principalColumn: "SharedExperienceId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                columns: new[] { "ProviderId", "Address", "CVR", "PhoneNumber", "TouristicOperatorPermitPdf" },
                values: new object[,]
                {
                    { 1, "Sunset Boulevard 21B, 8000", 12345678, "+4543219876", new byte[] { 1, 2, 5, 4, 5 } },
                    { 2, "Lakeside Road 8, 5000", 87654321, "+4578945632", new byte[] { 1, 4, 3, 4, 5 } },
                    { 3, "Mountain View 12, 3400", 87652321, "+4598765432", new byte[] { 2, 3, 3, 4, 5 } },
                    { 4, "Coastal Lane 5A, 6000", 82654321, "+4543219876", new byte[] { 1, 2, 3, 4, 5 } }
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

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ExperienceId",
                table: "Discounts",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_ProviderId",
                table: "Experiences",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceSharedExperience_SharedExperiencesSharedExperienceId",
                table: "ExperienceSharedExperience",
                column: "SharedExperiencesSharedExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestSharedExperience_SharedExperiencesSharedExperienceId",
                table: "GuestSharedExperience",
                column: "SharedExperiencesSharedExperienceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "ExperienceSharedExperience");

            migrationBuilder.DropTable(
                name: "GuestSharedExperience");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "SharedExperiences");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
