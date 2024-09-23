using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtisanServiceEntity_ArtisanEntity_Ref_Artisan",
                table: "ArtisanServiceEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtisanServiceEntity_ServiceEntity_ServiceId",
                table: "ArtisanServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceEntity",
                table: "ServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtisanServiceEntity",
                table: "ArtisanServiceEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtisanEntity",
                table: "ArtisanEntity");

            migrationBuilder.RenameTable(
                name: "ServiceEntity",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "ArtisanServiceEntity",
                newName: "ArtisanServices");

            migrationBuilder.RenameTable(
                name: "ArtisanEntity",
                newName: "Artisans");

            migrationBuilder.RenameIndex(
                name: "IX_ArtisanServiceEntity_ServiceId",
                table: "ArtisanServices",
                newName: "IX_ArtisanServices_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtisanServices",
                table: "ArtisanServices",
                columns: new[] { "Ref_Artisan", "Ref_Service" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artisans",
                table: "Artisans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtisanServices_Artisans_Ref_Artisan",
                table: "ArtisanServices",
                column: "Ref_Artisan",
                principalTable: "Artisans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtisanServices_Services_ServiceId",
                table: "ArtisanServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtisanServices_Artisans_Ref_Artisan",
                table: "ArtisanServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ArtisanServices_Services_ServiceId",
                table: "ArtisanServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtisanServices",
                table: "ArtisanServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artisans",
                table: "Artisans");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "ServiceEntity");

            migrationBuilder.RenameTable(
                name: "ArtisanServices",
                newName: "ArtisanServiceEntity");

            migrationBuilder.RenameTable(
                name: "Artisans",
                newName: "ArtisanEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ArtisanServices_ServiceId",
                table: "ArtisanServiceEntity",
                newName: "IX_ArtisanServiceEntity_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceEntity",
                table: "ServiceEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtisanServiceEntity",
                table: "ArtisanServiceEntity",
                columns: new[] { "Ref_Artisan", "Ref_Service" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtisanEntity",
                table: "ArtisanEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtisanServiceEntity_ArtisanEntity_Ref_Artisan",
                table: "ArtisanServiceEntity",
                column: "Ref_Artisan",
                principalTable: "ArtisanEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArtisanServiceEntity_ServiceEntity_ServiceId",
                table: "ArtisanServiceEntity",
                column: "ServiceId",
                principalTable: "ServiceEntity",
                principalColumn: "Id");
        }
    }
}
