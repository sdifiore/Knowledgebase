using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class OnePlataformaManyErros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Plataformas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_ErroId",
                table: "Plataformas",
                column: "ErroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plataformas_Erros_ErroId",
                table: "Plataformas",
                column: "ErroId",
                principalTable: "Erros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plataformas_Erros_ErroId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Plataformas_ErroId",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Plataformas");
        }
    }
}
