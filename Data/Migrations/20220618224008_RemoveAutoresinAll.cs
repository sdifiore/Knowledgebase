﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Knowledgebase.Data.Migrations
{
    public partial class RemoveAutoresinAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Consulta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FonteId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autores_Fontes_FonteId",
                        column: x => x.FonteId,
                        principalTable: "Fontes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChavePesquisaId = table.Column<int>(type: "int", nullable: false),
                    FrameworkId = table.Column<int>(type: "int", nullable: false),
                    PlataformaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consulta_Erros_ChavePesquisaId",
                        column: x => x.ChavePesquisaId,
                        principalTable: "Erros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Frameworks_FrameworkId",
                        column: x => x.FrameworkId,
                        principalTable: "Frameworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Plataformas_PlataformaId",
                        column: x => x.PlataformaId,
                        principalTable: "Plataformas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autores_FonteId",
                table: "Autores",
                column: "FonteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ChavePesquisaId",
                table: "Consulta",
                column: "ChavePesquisaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_FrameworkId",
                table: "Consulta",
                column: "FrameworkId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PlataformaId",
                table: "Consulta",
                column: "PlataformaId");
        }
    }
}
