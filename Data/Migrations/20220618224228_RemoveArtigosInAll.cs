using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class RemoveArtigosInAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropTable(
                name: "Artigos");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Fontes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Fontes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chamada = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Corpo = table.Column<string>(type: "nvarchar(max)", maxLength: 10240, nullable: false),
                    DiaMesAno = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes",
                column: "ArtigoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");
        }
    }
}
