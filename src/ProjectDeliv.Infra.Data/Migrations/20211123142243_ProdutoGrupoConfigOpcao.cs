using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDeliv.Infra.Data.Migrations
{
    public partial class ProdutoGrupoConfigOpcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoGrupoConfigOpcao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Codigo = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Preco = table.Column<double>(type: "REAL", nullable: false),
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
                    table.PrimaryKey("PK_ProdutoGrupoConfigOpcao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoGrupoConfigProdutoGrupoConfigOpcao",
                columns: table => new
                {
                    ProdutoGrupoConfigOpcoesId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProdutoGrupoConfigsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoGrupoConfigProdutoGrupoConfigOpcao", x => new { x.ProdutoGrupoConfigOpcoesId, x.ProdutoGrupoConfigsId });
                    table.ForeignKey(
                        name: "FK_ProdutoGrupoConfigProdutoGrupoConfigOpcao_ProdutoGrupoConfig_ProdutoGrupoConfigsId",
                        column: x => x.ProdutoGrupoConfigsId,
                        principalTable: "ProdutoGrupoConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoGrupoConfigProdutoGrupoConfigOpcao_ProdutoGrupoConfigOpcao_ProdutoGrupoConfigOpcoesId",
                        column: x => x.ProdutoGrupoConfigOpcoesId,
                        principalTable: "ProdutoGrupoConfigOpcao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoGrupoConfigProdutoGrupoConfigOpcao_ProdutoGrupoConfigsId",
                table: "ProdutoGrupoConfigProdutoGrupoConfigOpcao",
                column: "ProdutoGrupoConfigsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoGrupoConfigProdutoGrupoConfigOpcao");

            migrationBuilder.DropTable(
                name: "ProdutoGrupoConfigOpcao");
        }
    }
}
