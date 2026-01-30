using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guests",
                table: "Bookings",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Bookings",
                newName: "BookingTime");

            migrationBuilder.AddColumn<int>(
                name: "TableId1",
                table: "Bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TableId1",
                table: "Bookings",
                column: "TableId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tables_TableId1",
                table: "Bookings",
                column: "TableId1",
                principalTable: "Tables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tables_TableId1",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TableId1",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TableId1",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Persons",
                table: "Bookings",
                newName: "Guests");

            migrationBuilder.RenameColumn(
                name: "BookingTime",
                table: "Bookings",
                newName: "Date");
        }
    }
}
