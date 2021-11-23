using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDeliv.Domain.Entidades;

namespace ProjectDeliv.Infra.Data.Mapping
{
    public class ProdutoGrupoConfigMap : IEntityTypeConfiguration<ProdutoGrupoConfig>
    {
        public void Configure(EntityTypeBuilder<ProdutoGrupoConfig> builder)
        {
            builder.HasQueryFilter(produtoGrupoConfig => !produtoGrupoConfig.Deletado);

            builder.Property(produtoGrupoConfig => produtoGrupoConfig.Descricao).HasMaxLength(100);

            builder.HasOne(produtoGrupoConfig => produtoGrupoConfig.ProdutoGrupo)
                .WithMany(produtoGrupo => produtoGrupo.Configuracoes)
                .HasForeignKey(produtoGrupoConfig => produtoGrupoConfig.ProdutoGrupoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(produtoGrupoConfig => produtoGrupoConfig.ProdutoGrupoConfigOpcoes)
                .WithMany(produtoGrupoConfigOpcao => produtoGrupoConfigOpcao.ProdutoGrupoConfigs);
        }
    }
}
