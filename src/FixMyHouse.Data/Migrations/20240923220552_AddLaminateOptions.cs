using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLaminateOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a") },
                column: "CustomizationDefaults",
                value: "[{\"$type\":\"whole-number\",\"ValueMultiplier\":55,\"Value\":70,\"Id\":\"da89dcb9-ee1a-4eb2-b09c-5d6a0c0e0bca\",\"Name\":\"\\u041E\\u0431\\u0449 \\u0440\\u0430\\u0437\\u043C\\u0435\\u0440 \\u043D\\u0430 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\\u0442\\u0430 (\\u043A\\u0432.\\u043C)\",\"Description\":\"\\u041E\\u0431\\u0449\\u0430 \\u043A\\u0432\\u0430\\u0434\\u0440\\u0430\\u0442\\u0443\\u0440\\u0430 \\u043D\\u0430 \\u0432\\u0441\\u0438\\u0447\\u043A\\u0438 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F (\\u0434\\u043D\\u0435\\u0432\\u043D\\u0430, \\u043A\\u0443\\u0445\\u043D\\u044F, \\u0441\\u043F\\u0430\\u043B\\u043D\\u044F) 55\\u043B\\u0432/\\u043A\\u0432.\\u043C\"},{\"$type\":\"whole-number\",\"ValueMultiplier\":300,\"Value\":1,\"Id\":\"7d666de3-5f4f-4110-883d-100fe2ea4c2c\",\"Name\":\"\\u0411\\u0440\\u043E\\u0439 \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u044F\",\"Description\":\"\\u002B300\\u043B\\u0432 / \\u043F\\u043E\\u043C\\u0435\\u0449\\u0435\\u043D\\u0438\\u0435\"},{\"$type\":\"options\",\"AvailableOptions\":[{\"Id\":\"13f5e1d4-38d7-4189-84c7-a11765e3eac2\",\"Name\":\"\\u041C\\u043E\\u043A\\u0435\\u0442\",\"Price\":100},{\"Id\":\"e7671bf6-061e-4bb5-bd85-65caf770936f\",\"Name\":\"\\u041B\\u0430\\u043C\\u0438\\u043D\\u0430\\u0442\",\"Price\":150},{\"Id\":\"dbd2051b-8753-4454-9eee-f5655093b111\",\"Name\":\"\\u041F\\u0430\\u0440\\u043A\\u0435\\u0442\",\"Price\":300},{\"Id\":\"dbd2051b-8753-4454-9eee-f5655093b111\",\"Name\":\"\\u0411\\u0430\\u043B\\u0430\\u0442\\u0443\\u043C\",\"Price\":75}],\"Value\":\"13f5e1d4-38d7-4189-84c7-a11765e3eac2\",\"Id\":\"130820ee-1ec2-418f-b113-8485bc168d29\",\"Name\":\"\\u0412\\u0438\\u0434 \\u043D\\u0430\\u0441\\u0442\\u0438\\u043B\\u043A\\u0430\",\"Description\":\"\\u0418\\u0437\\u0431\\u0435\\u0440\\u0435\\u0442\\u0435 \\u043A\\u0430\\u043A \\u0434\\u0430 \\u0438\\u0437\\u043B\\u0435\\u0436\\u0434\\u0430 \\u0432\\u0430\\u0448\\u0438\\u044F\\u0442 \\u043F\\u043E\\u0434\"}]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a") },
                column: "CustomizationDefaults",
                value: "[]");
        }
    }
}
