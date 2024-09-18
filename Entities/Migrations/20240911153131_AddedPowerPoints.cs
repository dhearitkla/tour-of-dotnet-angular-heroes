using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    public partial class AddedPowerPoints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Power",
                table: "Teams",
                newName: "PowerPoints");

            migrationBuilder.RenameColumn(
                name: "Power",
                table: "Heroes",
                newName: "PowerPoints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PowerPoints",
                table: "Teams",
                newName: "Power");

            migrationBuilder.RenameColumn(
                name: "PowerPoints",
                table: "Heroes",
                newName: "Power");
        }
    }
}
