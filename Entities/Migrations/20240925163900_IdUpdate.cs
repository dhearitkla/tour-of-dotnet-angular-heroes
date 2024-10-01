using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    public partial class IdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Superpowers",
                newName: "SuperpowerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Heroes",
                newName: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SuperpowerId",
                table: "Superpowers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HeroId",
                table: "Heroes",
                newName: "Id");
        }
    }
}
