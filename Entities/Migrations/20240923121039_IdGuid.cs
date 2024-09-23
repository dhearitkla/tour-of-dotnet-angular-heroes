using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    public partial class IdGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SuperPowers_Heroes_HeroId",
                table: "SuperPowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperPowers",
                table: "SuperPowers");

            migrationBuilder.RenameTable(
                name: "SuperPowers",
                newName: "Superpowers");

            migrationBuilder.RenameIndex(
                name: "IX_SuperPowers_HeroId",
                table: "Superpowers",
                newName: "IX_Superpowers_HeroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superpowers",
                table: "Superpowers",
                column: "SuperpowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Superpowers_Heroes_HeroId",
                table: "Superpowers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Superpowers_Heroes_HeroId",
                table: "Superpowers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Superpowers",
                table: "Superpowers");

            migrationBuilder.RenameTable(
                name: "Superpowers",
                newName: "SuperPowers");

            migrationBuilder.RenameIndex(
                name: "IX_Superpowers_HeroId",
                table: "SuperPowers",
                newName: "IX_SuperPowers_HeroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperPowers",
                table: "SuperPowers",
                column: "SuperpowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SuperPowers_Heroes_HeroId",
                table: "SuperPowers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId");
        }
    }
}
