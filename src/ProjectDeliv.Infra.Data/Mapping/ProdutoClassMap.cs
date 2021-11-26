using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDeliv.Domain.Entidades;

namespace ProjectDeliv.Infra.Data.Mapping
{
    public class ProdutoClassMap : IEntityTypeConfiguration<ProdutoClass>
    {
        public void Configure(EntityTypeBuilder<ProdutoClass> builder)
        {
            builder.Property(produtoClass => produtoClass.Descricao).HasMaxLength(100).IsRequired();
            builder.Property(produtoClass => produtoClass.ImagemUrl).HasMaxLength(500).IsRequired(false);
        }
    }
}
