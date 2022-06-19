using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Migrations
{
    public partial class AddFontesNavStd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fontes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ErroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fontes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fontes_Erros_ErroId",
                        column: x => x.ErroId,
                        principalTable: "Erros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fontes_ErroId",
                table: "Fontes",
                column: "ErroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fontes");
        }
    }
}
