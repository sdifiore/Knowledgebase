using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Migrations
{
    public partial class AddArtigosNavStd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artigos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chamada = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Corpo = table.Column<string>(type: "nvarchar(max)", maxLength: 10240, nullable: false),
                    FonteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artigos_Fontes_FonteId",
                        column: x => x.FonteId,
                        principalTable: "Fontes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artigos_FonteId",
                table: "Artigos",
                column: "FonteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artigos");
        }
    }
}
