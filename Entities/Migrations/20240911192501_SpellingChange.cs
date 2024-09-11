using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour_of_dotnet_angular_heros.Migrations
{
    public partial class SpellingChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SuperPowerId",
                table: "SuperPowers",
                newName: "SuperpowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SuperpowerId",
                table: "SuperPowers",
                newName: "SuperPowerId");
        }
    }
}
