using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstronautsDataLibrary.Migrations
{
    public partial class StartUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superpowers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superpowers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Astronauts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "DATE", nullable: false),
                    SuperpowerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Astronauts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Astronauts_Superpowers_SuperpowerId",
                        column: x => x.SuperpowerId,
                        principalTable: "Superpowers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Astronauts_SuperpowerId",
                table: "Astronauts",
                column: "SuperpowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Astronauts");

            migrationBuilder.DropTable(
                name: "Superpowers");
        }
    }
}
