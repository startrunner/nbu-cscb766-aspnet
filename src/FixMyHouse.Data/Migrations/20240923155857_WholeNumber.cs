using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class WholeNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("4522c17e-c161-4f42-8467-1854344a373b") },
                column: "CustomizationDefaults",
                value: "[{\"$type\":\"checkbox\",\"ValueIfTrue\":100,\"Value\":false,\"Id\":\"525e7b61-27d7-4995-9338-9119b54b63b5\",\"Name\":\"\\u0415\\u043A\\u0441\\u0442\\u0440\\u0430 \\u0434\\u044E\\u0431\\u0435\\u043B\\u0438\",\"Description\":\"\\u002B2 \\u0433\\u043E\\u0434\\u0438\\u043D\\u0438 \\u0433\\u0430\\u0440\\u0430\\u043D\\u0446\\u0438\\u044F\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":50,\"Value\":20,\"Id\":\"9aa0097e-135a-47af-beb3-0e3739662e51\",\"Name\":\"\\u0412\\u044A\\u043D\\u0448\\u043D\\u0430 \\u043A\\u0432\\u0430\\u0434\\u0440\\u0430\\u0442\\u0443\\u0440\\u0430\",\"Description\":\"50 \\u043B\\u0432/\\u043A\\u0432.\\u043C\"}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("4522c17e-c161-4f42-8467-1854344a373b") },
                column: "CustomizationDefaults",
                value: "[{\"$type\":\"checkbox\",\"ValueIfTrue\":100,\"Value\":false,\"Id\":\"525e7b61-27d7-4995-9338-9119b54b63b5\",\"Name\":\"\\u0415\\u043A\\u0441\\u0442\\u0440\\u0430 \\u0434\\u044E\\u0431\\u0435\\u043B\\u0438\",\"Description\":\"\\u002B2 \\u0433\\u043E\\u0434\\u0438\\u043D\\u0438 \\u0433\\u0430\\u0440\\u0430\\u043D\\u0446\\u0438\\u044F\"}]");
        }
    }
}
