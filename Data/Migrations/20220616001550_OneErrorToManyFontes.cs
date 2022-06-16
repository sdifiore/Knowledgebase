using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class OneErrorToManyFontes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Fontes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes",
                column: "ErroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fontes_Erros_ErroId",
                table: "Fontes",
                column: "ErroId",
                principalTable: "Erros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Erros_ErroId",
                table: "Fontes");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Fontes");
        }
    }
}
