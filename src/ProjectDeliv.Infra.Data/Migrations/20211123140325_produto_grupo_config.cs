using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDeliv.Infra.Data.Migrations
{
    public partial class produto_grupo_config : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdutoGrupoConfig",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProdutoGrupoId = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    table.PrimaryKey("PK_ProdutoGrupoConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoGrupoConfig_ProdutoGrupo_ProdutoGrupoId",
                        column: x => x.ProdutoGrupoId,
                        principalTable: "ProdutoGrupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoGrupoConfig_ProdutoGrupoId",
                table: "ProdutoGrupoConfig",
                column: "ProdutoGrupoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoGrupoConfig");
        }
    }
}
