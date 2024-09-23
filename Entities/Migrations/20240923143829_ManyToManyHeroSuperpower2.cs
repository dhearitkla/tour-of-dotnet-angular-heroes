using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tour.of.dotnet.angular.heroes.Migrations
{
    public partial class ManyToManyHeroSuperpower2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Superpowers_Heroes_HeroId",
                table: "Superpowers");

            migrationBuilder.DropIndex(
                name: "IX_Superpowers_HeroId",
                table: "Superpowers");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "Superpowers");

            migrationBuilder.CreateTable(
                name: "HeroSuperpower",
                columns: table => new
                {
                    HeroesHeroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuperpowersSuperpowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroSuperpower", x => new { x.HeroesHeroId, x.SuperpowersSuperpowerId });
                    table.ForeignKey(
                        name: "FK_HeroSuperpower_Heroes_HeroesHeroId",
                        column: x => x.HeroesHeroId,
                        principalTable: "Heroes",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroSuperpower_Superpowers_SuperpowersSuperpowerId",
                        column: x => x.SuperpowersSuperpowerId,
                        principalTable: "Superpowers",
                        principalColumn: "SuperpowerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroSuperpower_SuperpowersSuperpowerId",
                table: "HeroSuperpower",
                column: "SuperpowersSuperpowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroSuperpower");

            migrationBuilder.AddColumn<Guid>(
                name: "HeroId",
                table: "Superpowers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Superpowers_HeroId",
                table: "Superpowers",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Superpowers_Heroes_HeroId",
                table: "Superpowers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "HeroId");
        }
    }
}
