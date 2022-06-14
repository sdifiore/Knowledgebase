using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class DemoteAutoresRelationToErrors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Artigos_ArtigoId",
                table: "Autores");

            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Erros_ErroId",
                table: "Autores");

            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Erros_ErroId",
                table: "Fontes");

            migrationBuilder.DropForeignKey(
                name: "FK_Frameworks_Artigos_ArtigoId",
                table: "Frameworks");

            migrationBuilder.DropForeignKey(
                name: "FK_Plataformas_Artigos_ArtigoId",
                table: "Plataformas");

            migrationBuilder.DropForeignKey(
                name: "FK_Plataformas_Erros_ErroId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Plataformas_ArtigoId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Plataformas_ErroId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Frameworks_ArtigoId",
                table: "Frameworks");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes");

            migrationBuilder.DropIndex(
                name: "IX_Autores_ArtigoId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_ErroId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Frameworks");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "Fonte",
                table: "Erros");

            migrationBuilder.DropColumn(
                name: "ArtigoId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Autores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Plataformas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErroId",
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
                name: "ErroId",
                table: "Fontes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fonte",
                table: "Erros",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArtigoId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_ArtigoId",
                table: "Plataformas",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_ErroId",
                table: "Plataformas",
                column: "ErroId");

            migrationBuilder.CreateIndex(
                name: "IX_Frameworks_ArtigoId",
                table: "Frameworks",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ArtigoId",
                table: "Fontes",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes",
                column: "ErroId");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_ArtigoId",
                table: "Autores",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_ErroId",
                table: "Autores",
                column: "ErroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Artigos_ArtigoId",
                table: "Autores",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Erros_ErroId",
                table: "Autores",
                column: "ErroId",
                principalTable: "Erros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fontes_Artigos_ArtigoId",
                table: "Fontes",
                column: "ArtigoId",
                principalTable: "Artigos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fontes_Erros_ErroId",
                table: "Fontes",
                column: "ErroId",
                principalTable: "Erros",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Plataformas_Erros_ErroId",
                table: "Plataformas",
                column: "ErroId",
                principalTable: "Erros",
                principalColumn: "Id");
        }
    }
}
