using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedArtisans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArtisanEntity",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("936f63da-8730-4344-8421-64bf343661f7"), "Петър", "Георгиев" },
                    { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), "Георги", "Петров" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtisanEntity",
                keyColumn: "Id",
                keyValue: new Guid("936f63da-8730-4344-8421-64bf343661f7"));

            migrationBuilder.DeleteData(
                table: "ArtisanEntity",
                keyColumn: "Id",
                keyValue: new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"));
        }
    }
}
