using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Music_Events.Migrations
{
    public partial class resolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Length",
                table: "Track",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Length",
                table: "Track",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AddColumn<int>(
                name: "TrackID",
                table: "Booking",
                type: "int",
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
    }
}
