using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDeliv.Infra.Data.Migrations
{
    public partial class produtoclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoClassId",
                table: "ProdutoGrupo",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProdutoClass",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ImagemUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Deletado = table.Column<bool>(type: "INTEGER", nullable: false),
                    InseridoPor = table.Column<string>(type: "TEXT", nullable: true),
                    InseridoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AtualizadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    AtualizadoEm = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletadoPor = table.Column<string>(type: "TEXT", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoClass", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoGrupo_ProdutoClassId",
                table: "ProdutoGrupo",
                column: "ProdutoClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoGrupo_ProdutoClass_ProdutoClassId",
                table: "ProdutoGrupo",
                column: "ProdutoClassId",
                principalTable: "ProdutoClass",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoGrupo_ProdutoClass_ProdutoClassId",
                table: "ProdutoGrupo");

            migrationBuilder.DropTable(
                name: "ProdutoClass");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoGrupo_ProdutoClassId",
                table: "ProdutoGrupo");

            migrationBuilder.DropColumn(
                name: "ProdutoClassId",
                table: "ProdutoGrupo");
        }
    }
}
