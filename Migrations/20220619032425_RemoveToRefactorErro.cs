using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Migrations
{
    public partial class RemoveToRefactorErro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Erros");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Erros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apelido = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ErroId = table.Column<int>(type: "int", nullable: false),
                    FrameworkId = table.Column<int>(type: "int", nullable: true),
                    Versao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Erros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Erros_Frameworks_FrameworkId",
                        column: x => x.FrameworkId,
                        principalTable: "Frameworks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Erros_FrameworkId",
                table: "Erros",
                column: "FrameworkId");
        }
    }
}
