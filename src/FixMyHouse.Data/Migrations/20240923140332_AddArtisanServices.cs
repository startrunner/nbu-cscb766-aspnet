using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddArtisanServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ArtisanServices");

            migrationBuilder.InsertData(
                table: "ArtisanServices",
                columns: new[] { "Ref_Artisan", "Ref_Service", "CustomizationDefaults", "ServiceId" },
                values: new object[,]
                {
                    { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"), "[]", null },
                    { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("4522c17e-c161-4f42-8467-1854344a373b"), "[]", null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4522c17e-c161-4f42-8467-1854344a373b"), "Външни и вътрешни топлоизолации", "Топлоизолация" },
                    { new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"), "Поставяне на плочки във вашата баня", "Лепене на плочки" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("608f46ff-bd6d-4025-8435-c768df3cb434") });

            migrationBuilder.DeleteData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("4522c17e-c161-4f42-8467-1854344a373b") });

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("4522c17e-c161-4f42-8467-1854344a373b"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ArtisanServices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
