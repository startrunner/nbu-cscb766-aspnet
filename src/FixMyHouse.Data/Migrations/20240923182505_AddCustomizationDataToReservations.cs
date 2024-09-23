using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomizationDataToReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomizationBooleans",
                table: "ServiceReservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomizationGuids",
                table: "ServiceReservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomizationWholeNumbers",
                table: "ServiceReservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomizationBooleans",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "CustomizationGuids",
                table: "ServiceReservations");

            migrationBuilder.DropColumn(
                name: "CustomizationWholeNumbers",
                table: "ServiceReservations");
        }
    }
}
