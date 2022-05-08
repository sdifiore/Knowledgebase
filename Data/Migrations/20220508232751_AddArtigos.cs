using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class AddArtigos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Plataformas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Frameworks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Fontes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Autores",
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
                name: "IX_Plataformas_ArtigoId",
                table: "Plataformas",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Frameworks_ArtigoId",
                table: "Frameworks",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_ArtigoId",
                table: "Autores",
                column: "ArtigoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Artigos_ArtigoId",
                table: "Autores",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Frameworks_Artigos_ArtigoId",
                table: "Frameworks",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Plataformas_Artigos_ArtigoId",
                table: "Plataformas",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Artigos_ArtigoId",
                table: "Autores");

            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropForeignKey(
                name: "FK_Frameworks_Artigos_ArtigoId",
                table: "Frameworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Plataformas_Artigos_ArtigoId",
                table: "Plataformas");

            migrationBuilder.DropTable(
                name: "Artigos");

            migrationBuilder.DropIndex(
                name: "IX_Plataformas_ArtigoId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Frameworks_ArtigoId",
                table: "Frameworks");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropIndex(
                name: "IX_Autores_ArtigoId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Frameworks");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Autores");
        }
    }
}
