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

            builder.HasOne(produtoGrupo => produtoGrupo.ProdutoClass)
                .WithMany(produtoClass => produtoClass.Grupos)
                .HasForeignKey(produtoGrupo => produtoGrupo.ProdutoClassId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(produtoGrupo => produtoGrupo.Descricao)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
