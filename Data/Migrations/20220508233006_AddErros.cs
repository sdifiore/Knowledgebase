using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class AddErros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Plataformas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Fontes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ErroId",
                table: "Autores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Erros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Fonte = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_ErroId",
                table: "Plataformas",
                column: "ErroId");

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes",
                column: "ErroId");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_ErroId",
                table: "Autores",
                column: "ErroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autores_Erros_ErroId",
                table: "Autores",
                column: "ErroId",
                principalTable: "Erros",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fontes_Erros_ErroId",
                table: "Fontes",
                column: "ErroId",
                principalTable: "Erros",
                principalColumn: "Id");

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
                name: "FK_Autores_Erros_ErroId",
                table: "Autores");

            migrationBuilder.DropForeignKey(
                name: "FK_Fontes_Erros_ErroId",
                table: "Fontes");

            migrationBuilder.DropForeignKey(
                name: "FK_Plataformas_Erros_ErroId",
                table: "Plataformas");

            migrationBuilder.DropTable(
                name: "Erros");

            migrationBuilder.DropIndex(
                name: "IX_Plataformas_ErroId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes");

            migrationBuilder.DropIndex(
                name: "IX_Autores_ErroId",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Fontes");

            migrationBuilder.DropColumn(
                name: "ErroId",
                table: "Autores");
        }
    }
}
