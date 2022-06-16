using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class OnePlataformaToManyFrameworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlataformaId",
                table: "Frameworks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Frameworks_PlataformaId",
                table: "Frameworks",
                column: "PlataformaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Frameworks_Plataformas_PlataformaId",
                table: "Frameworks",
                column: "PlataformaId",
                principalTable: "Plataformas",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frameworks_Plataformas_PlataformaId",
                table: "Frameworks");

            migrationBuilder.DropIndex(
                name: "IX_Frameworks_PlataformaId",
                table: "Frameworks");

            migrationBuilder.DropColumn(
                name: "PlataformaId",
                table: "Frameworks");
        }
    }
}
