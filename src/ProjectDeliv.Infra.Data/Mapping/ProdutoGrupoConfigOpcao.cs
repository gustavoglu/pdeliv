using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDeliv.Domain.Entidades;

namespace ProjectDeliv.Infra.Data.Mapping
{
    public class ProdutoGrupoConfigOpcaoMap : IEntityTypeConfiguration<ProdutoGrupoConfigOpcao>
    {
        public void Configure(EntityTypeBuilder<ProdutoGrupoConfigOpcao> builder)
        {
            builder.HasQueryFilter(produtoGrupoConfig => !produtoGrupoConfig.Deletado);

            builder.Property(ProdutoGrupoConfigOpcao => ProdutoGrupoConfigOpcao.Descricao).HasMaxLength(100);
            builder.Property(ProdutoGrupoConfigOpcao => ProdutoGrupoConfigOpcao.Codigo).IsRequired();

            builder.HasMany(produtoGrupoConfigOpcao => produtoGrupoConfigOpcao.ProdutoGrupoConfigs)
                .WithMany(produtoGrupoConfig => produtoGrupoConfig.ProdutoGrupoConfigOpcoes);

        }
    }
}
