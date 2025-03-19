using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aflevering_2.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Experiences",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 1,
                column: "Price",
                value: 350);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 2,
                column: "Price",
                value: 450);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 3,
                column: "Price",
                value: 600);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 4,
                column: "Price",
                value: 275);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 5,
                column: "Price",
                value: 220);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 6,
                column: "Price",
                value: 750);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 7,
                column: "Price",
                value: 525);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Experiences",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 1,
                column: "Price",
                value: 350.0);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 2,
                column: "Price",
                value: 450.0);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 3,
                column: "Price",
                value: 600.0);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 4,
                column: "Price",
                value: 275.0);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 5,
                column: "Price",
                value: 220.0);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 6,
                column: "Price",
                value: 750.0);

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "ExperienceId",
                keyValue: 7,
                column: "Price",
                value: 525.0);
        }
    }
}
