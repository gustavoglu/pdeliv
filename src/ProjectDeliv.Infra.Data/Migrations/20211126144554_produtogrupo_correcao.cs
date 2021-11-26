using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectDeliv.Infra.Data.Migrations
{
    public partial class produtogrupo_correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemUrl",
                table: "ProdutoGrupo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemUrl",
                table: "ProdutoGrupo",
                type: "TEXT",
                maxLength: 250,
                nullable: true);
        }
    }
}
