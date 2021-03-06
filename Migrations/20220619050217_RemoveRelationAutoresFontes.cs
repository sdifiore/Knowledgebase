using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Migrations
{
    public partial class RemoveRelationAutoresFontes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autores_Fontes_FonteId",
                table: "Autores");

            migrationBuilder.DropIndex(
                name: "IX_Autores_FonteId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "FonteId",
                table: "Autores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FonteId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Autores_FonteId",
                table: "Autores",
                column: "FonteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Fontes_FonteId",
                table: "Autores",
                column: "FonteId",
                principalTable: "Fontes",
                principalColumn: "Id");
        }
    }
}
