using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDeliv.Domain.Entidades;

namespace ProjectDeliv.Infra.Data.Mapping
{
    public class ProdutoGrupoMap : IEntityTypeConfiguration<ProdutoGrupo>
    {
        public void Configure(EntityTypeBuilder<ProdutoGrupo> builder)
        {
            builder.HasQueryFilter(produtoGrupo => produtoGrupo.Deletado == false);

            builder.Property(produtoGrupo => produtoGrupo.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(produtoGrupo => produtoGrupo.ImagemUrl)
                .HasMaxLength(250)
                .IsRequired(false);

        }
    }
}
