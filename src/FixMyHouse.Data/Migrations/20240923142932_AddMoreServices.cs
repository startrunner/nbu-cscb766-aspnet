using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Artisans",
                keyColumn: "Id",
                keyValue: new Guid("936f63da-8730-4344-8421-64bf343661f7"),
                column: "Bio",
                value: "Петър е майстор по вътрешни ремонти и бани");

            migrationBuilder.UpdateData(
                table: "Artisans",
                keyColumn: "Id",
                keyValue: new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
                column: "Bio",
                value: "Георги е алпинист и специализира в покриви и външни топлоизолации");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"), "Поставяне на подова настилка: паркет, ламинат, мокети и балатум", "Подова настилка" },
                    { new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"), "Хидроизолация на покриви на жилищни сгради. Обадете се, ако покрива тече!", "Хидроизолация на покриви" }
                });

            migrationBuilder.InsertData(
                table: "ArtisanServices",
                columns: new[] { "Ref_Artisan", "Ref_Service", "CustomizationDefaults" },
                values: new object[,]
                {
                    { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"), "[]" },
                    { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"), "[]" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a") });

            migrationBuilder.DeleteData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d") });

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"));

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"));

            migrationBuilder.UpdateData(
                table: "Artisans",
                keyColumn: "Id",
                keyValue: new Guid("936f63da-8730-4344-8421-64bf343661f7"),
                column: "Bio",
                value: "Петър е майстор и лепи плочки.");

            migrationBuilder.UpdateData(
                table: "Artisans",
                keyColumn: "Id",
                keyValue: new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
                column: "Bio",
                value: "Георги е алпинист и прави топлоизолации.");
        }
    }
}
