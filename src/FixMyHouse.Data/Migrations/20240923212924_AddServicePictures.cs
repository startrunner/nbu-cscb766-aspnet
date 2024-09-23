using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddServicePictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("4522c17e-c161-4f42-8467-1854344a373b"),
                column: "Picture",
                value: "thermal-insulation.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"),
                column: "Picture",
                value: "laminate.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"),
                column: "Picture",
                value: "bathroom-tiles.png");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"),
                column: "Picture",
                value: "roof-hydro.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Services");
        }
    }
}
