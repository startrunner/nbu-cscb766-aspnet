using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddArtisanPictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Artisans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Artisans",
                keyColumn: "Id",
                keyValue: new Guid("936f63da-8730-4344-8421-64bf343661f7"),
                column: "Picture",
                value: "pesho.png");

            migrationBuilder.UpdateData(
                table: "Artisans",
                keyColumn: "Id",
                keyValue: new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
                column: "Picture",
                value: "gosho.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Artisans");
        }
    }
}
