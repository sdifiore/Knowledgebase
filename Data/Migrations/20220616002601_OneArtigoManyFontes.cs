using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class OneArtigoManyFontes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Fontes",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Fontes");
        }
    }
}
