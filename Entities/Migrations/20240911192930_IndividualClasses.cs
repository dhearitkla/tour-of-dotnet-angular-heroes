using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    public partial class IndividualClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerPoints",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PowerPoints",
                table: "Heroes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PowerPoints",
                table: "Teams",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerPoints",
                table: "Heroes",
                type: "INTEGER",
                nullable: true);
        }
    }
}
