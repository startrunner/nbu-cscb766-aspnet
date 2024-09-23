using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtisanServices_Services_ServiceId",
                table: "ArtisanServices");

            migrationBuilder.DropIndex(
                name: "IX_ArtisanServices_ServiceId",
                table: "ArtisanServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "ArtisanServices");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Artisans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_ArtisanServices_Ref_Service",
                table: "ArtisanServices",
                column: "Ref_Service");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtisanServices_Services_Ref_Service",
                table: "ArtisanServices",
                column: "Ref_Service",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtisanServices_Services_Ref_Service",
                table: "ArtisanServices");

            migrationBuilder.DropIndex(
                name: "IX_ArtisanServices_Ref_Service",
                table: "ArtisanServices");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Artisans");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceId",
                table: "ArtisanServices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("936f63da-8730-4344-8421-64bf343661f7"), new Guid("608f46ff-bd6d-4025-8435-c768df3cb434") },
                column: "ServiceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ArtisanServices",
                keyColumns: new[] { "Ref_Artisan", "Ref_Service" },
                keyValues: new object[] { new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"), new Guid("4522c17e-c161-4f42-8467-1854344a373b") },
                column: "ServiceId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ArtisanServices_ServiceId",
                table: "ArtisanServices",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtisanServices_Services_ServiceId",
                table: "ArtisanServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
