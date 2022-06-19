using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Migrations
{
    public partial class AddAutoresNavStd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FonteId = table.Column<int>(type: "int", nullable: true),
                    ArtigoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autores_Artigos_ArtigoId",
                        column: x => x.ArtigoId,
                        principalTable: "Artigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Autores_Fontes_FonteId",
                        column: x => x.FonteId,
                        principalTable: "Fontes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_ArtigoId",
                table: "Autores",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Autores_FonteId",
                table: "Autores",
                column: "FonteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
