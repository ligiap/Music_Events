using Microsoft.EntityFrameworkCore.Migrations;

namespace Music_Events.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Event");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Event",
                type: "int",
                nullable: true);
        }
    }
}
