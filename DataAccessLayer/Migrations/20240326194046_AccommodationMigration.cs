using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusQuartersAPI.Migrations
{
    /// <inheritdoc />
    public partial class AccommodationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "AccommodationVideos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccommodationId",
                table: "AccommodationImages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    LandlordId = table.Column<int>(type: "int", nullable: false),
                    Photographed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deposit = table.Column<double>(type: "float", nullable: false),
                    Rent = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodations_AccommodationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccommodationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accommodations_Availability_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accommodations_Landlords_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Landlords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationVideos_AccommodationId",
                table: "AccommodationVideos",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImages_AccommodationId",
                table: "AccommodationImages",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_AvailabilityId",
                table: "Accommodations",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_LandlordId",
                table: "Accommodations",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_TypeId",
                table: "Accommodations",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationImages_Accommodations_AccommodationId",
                table: "AccommodationImages",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationVideos_Accommodations_AccommodationId",
                table: "AccommodationVideos",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationImages_Accommodations_AccommodationId",
                table: "AccommodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationVideos_Accommodations_AccommodationId",
                table: "AccommodationVideos");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropIndex(
                name: "IX_AccommodationVideos_AccommodationId",
                table: "AccommodationVideos");

            migrationBuilder.DropIndex(
                name: "IX_AccommodationImages_AccommodationId",
                table: "AccommodationImages");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "AccommodationVideos");

            migrationBuilder.DropColumn(
                name: "AccommodationId",
                table: "AccommodationImages");
        }
    }
}
