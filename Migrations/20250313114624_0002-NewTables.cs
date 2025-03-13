using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aflevering_2.Migrations
{
    /// <inheritdoc />
    public partial class _0002NewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Experiences",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceSharedExperience_SharedExperiencesSharedExperienceId",
                table: "ExperienceSharedExperience",
                column: "SharedExperiencesSharedExperienceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperienceSharedExperience");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Experiences",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
