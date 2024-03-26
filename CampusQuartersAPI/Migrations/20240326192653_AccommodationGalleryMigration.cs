using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusQuartersAPI.Migrations
{
    /// <inheritdoc />
    public partial class AccommodationGalleryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccommodationImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotographerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationImages_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationVideos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateUploaded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTaken = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotographerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccommodationVideos_Photographers_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationImages_PhotographerId",
                table: "AccommodationImages",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationVideos_PhotographerId",
                table: "AccommodationVideos",
                column: "PhotographerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationImages");

            migrationBuilder.DropTable(
                name: "AccommodationVideos");
        }
    }
}
