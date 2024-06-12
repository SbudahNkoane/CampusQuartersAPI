using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampusQuartersAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationImages_Photographers_PhotographerId",
                table: "AccommodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationVideos_Photographers_PhotographerId",
                table: "AccommodationVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_StatusId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Accommodations_AccommodationId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "AccommodationId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Availability",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "AccommodationVideos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "AccommodationImages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationImages_Photographers_PhotographerId",
                table: "AccommodationImages",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationVideos_Photographers_PhotographerId",
                table: "AccommodationVideos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_StatusId",
                table: "Availability",
                column: "StatusId",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Accommodations_AccommodationId",
                table: "Bookings",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationImages_Photographers_PhotographerId",
                table: "AccommodationImages");

            migrationBuilder.DropForeignKey(
                name: "FK_AccommodationVideos_Photographers_PhotographerId",
                table: "AccommodationVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_Availability_AvailabilityStatuses_StatusId",
                table: "Availability");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Accommodations_AccommodationId",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "AccommodationId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "AccommodationVideos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotographerId",
                table: "AccommodationImages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationImages_Photographers_PhotographerId",
                table: "AccommodationImages",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccommodationVideos_Photographers_PhotographerId",
                table: "AccommodationVideos",
                column: "PhotographerId",
                principalTable: "Photographers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_AvailabilityStatuses_StatusId",
                table: "Availability",
                column: "StatusId",
                principalTable: "AvailabilityStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Accommodations_AccommodationId",
                table: "Bookings",
                column: "AccommodationId",
                principalTable: "Accommodations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
