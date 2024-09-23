using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntroduceEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "ArtisanEntity",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ArtisanEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceEntity",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ServiceEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtisanServiceEntity",
                columns: table => new {
                    Ref_Artisan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ref_Service = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomizationDefaults = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ArtisanServiceEntity", x => new { x.Ref_Artisan, x.Ref_Service });
                    table.ForeignKey(
                        name: "FK_ArtisanServiceEntity_ArtisanEntity_Ref_Artisan",
                        column: x => x.Ref_Artisan,
                        principalTable: "ArtisanEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtisanServiceEntity_ServiceEntity_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtisanServiceEntity_ServiceId",
                table: "ArtisanServiceEntity",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtisanServiceEntity");

            migrationBuilder.DropTable(
                name: "ArtisanEntity");

            migrationBuilder.DropTable(
                name: "ServiceEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
