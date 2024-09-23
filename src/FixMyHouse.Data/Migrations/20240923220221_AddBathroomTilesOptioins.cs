using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBathroomTilesOptioins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("608f46ff-bd6d-4025-8435-c768df3cb434") },
                column: "CustomizationDefaults",
                value: "[{\"$type\":\"whole-number\",\"ValueMultiplier\":110,\"Value\":30,\"Id\":\"14a09ac4-3db2-43d1-a471-d6d74a95cd92\",\"Name\":\"\\u041E\\u0431\\u0449 \\u0440\\u0430\\u0437\\u043C\\u0435\\u0440 \\u043D\\u0430 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\\u0442\\u0430 (\\u043A\\u0432.\\u043C)\",\"Description\":\"\\u041E\\u0431\\u0449\\u0430 \\u043A\\u0432\\u0430\\u0434\\u0440\\u0430\\u0442\\u0443\\u0440\\u0430 \\u043D\\u0430 \\u0432\\u0441\\u0438\\u0447\\u043A\\u0438 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F (\\u0431\\u0430\\u043D\\u0438, \\u0442\\u043E\\u0430\\u043B\\u0435\\u0442\\u043D\\u0438) 110\\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":1000,\"Value\":1,\"Id\":\"69dc7312-25df-4705-8bf0-4fab9a5588b5\",\"Name\":\"\\u0411\\u0440\\u043E\\u0439 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\",\"Description\":\"\\u002B1000\\u043B\\u0432 / \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u0435\"}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("608f46ff-bd6d-4025-8435-c768df3cb434") },
                column: "CustomizationDefaults",
                value: "[]");
        }
    }
}
