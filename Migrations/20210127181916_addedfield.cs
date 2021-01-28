using Microsoft.EntityFrameworkCore.Migrations;

namespace Music_Events.Migrations
{
    public partial class addedfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackID",
                table: "Booking",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_TrackID",
                table: "Booking",
                column: "TrackID");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Track_TrackID",
                table: "Booking",
                column: "TrackID",
                principalTable: "Track",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Track_TrackID",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_TrackID",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "TrackID",
                table: "Booking");
        }
    }
}
