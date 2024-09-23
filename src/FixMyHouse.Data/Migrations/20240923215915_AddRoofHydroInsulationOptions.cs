using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoofHydroInsulationOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d") },
                column: "CustomizationDefaults",
                value: "[{\"$type\":\"whole-number\",\"ValueMultiplier\":70,\"Value\":250,\"Id\":\"de5a0771-df9d-408c-abce-864e54de37e8\",\"Name\":\"\\u0420\\u0430\\u0437\\u043C\\u0435\\u0440 \\u043D\\u0430 \\u043F\\u043E\\u043A\\u0440\\u0438\\u0432 (\\u043A\\u0432.\\u043C)\",\"Description\":\"\\u041A\\u043E\\u043B\\u043A\\u043E \\u0435 \\u0433\\u043E\\u043B\\u044F\\u043C \\u0432\\u0430\\u0448\\u0438\\u044F\\u0442 \\u043F\\u043E\\u043A\\u0440\\u0438\\u0432? 70\\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":100,\"Value\":1,\"Id\":\"0f49866d-1215-49ee-8d0f-d0ebdc8fecd5\",\"Name\":\"\\u0411\\u0440\\u043E\\u0439 \\u043A\\u043E\\u043C\\u0438\\u043D\\u0438 \\u0438 \\u0434\\u0440\\u0443\\u0433\\u0438 \\u043F\\u0440\\u0435\\u043F\\u044F\\u0442\\u0441\\u0442\\u0432\\u0438\\u044F\",\"Description\":\"100\\u043B\\u0432 / \\u043A\\u043E\\u043C\\u0438\\u043D\"}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d") },
                column: "CustomizationDefaults",
                value: "[]");
        }
    }
}
