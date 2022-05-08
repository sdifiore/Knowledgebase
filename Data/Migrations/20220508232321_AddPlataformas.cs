using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class AddPlataformas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plataformas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apelido = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FrameworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plataformas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plataformas_Frameworks_FrameworkId",
                        column: x => x.FrameworkId,
                        principalTable: "Frameworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_FrameworkId",
                table: "Plataformas",
                column: "FrameworkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plataformas");
        }
    }
}
