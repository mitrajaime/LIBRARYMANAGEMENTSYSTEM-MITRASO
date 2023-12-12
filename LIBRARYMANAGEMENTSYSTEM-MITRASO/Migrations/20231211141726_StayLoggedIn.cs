using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LIBRARYMANAGEMENTSYSTEM_MITRASO.Migrations
{
    public partial class StayLoggedIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StayLoggedIn",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StayLoggedIn",
                table: "User");
        }
    }
}
