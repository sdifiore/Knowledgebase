using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class RemovePlataformasRelationToArtigos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plataformas_Frameworks_FrameworkId",
                table: "Plataformas");

            migrationBuilder.DropIndex(
                name: "IX_Plataformas_FrameworkId",
                table: "Plataformas");

            migrationBuilder.DropColumn(
                name: "FrameworkId",
                table: "Plataformas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FrameworkId",
                table: "Plataformas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Plataformas_FrameworkId",
                table: "Plataformas",
                column: "FrameworkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plataformas_Frameworks_FrameworkId",
                table: "Plataformas",
                column: "FrameworkId",
                principalTable: "Frameworks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
