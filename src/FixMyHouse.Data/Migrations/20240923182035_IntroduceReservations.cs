using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FixMyHouse.Data.Migrations
{
    /// <inheritdoc />
    public partial class IntroduceReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceReservations",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WhenUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CalculatedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ref_Artisan = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ref_Service = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ref_User = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_ServiceReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceReservations_Artisans_Ref_Artisan",
                        column: x => x.Ref_Artisan,
                        principalTable: "Artisans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceReservations_AspNetUsers_Ref_User",
                        column: x => x.Ref_User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceReservations_Services_Ref_Service",
                        column: x => x.Ref_Service,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_Ref_Artisan",
                table: "ServiceReservations",
                column: "Ref_Artisan");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_Ref_Service",
                table: "ServiceReservations",
                column: "Ref_Service");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceReservations_Ref_User",
                table: "ServiceReservations",
                column: "Ref_User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceReservations");
        }
    }
}
