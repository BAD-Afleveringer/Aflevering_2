using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aflevering_2.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVR",
                table: "Providers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVR",
                table: "Providers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 1,
                column: "CVR",
                value: 12345678);

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 2,
                column: "CVR",
                value: 87654321);

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 3,
                column: "CVR",
                value: 87652321);

            migrationBuilder.UpdateData(
                table: "Providers",
                keyColumn: "ProviderId",
                keyValue: 4,
                column: "CVR",
                value: 82654321);
        }
    }
}
