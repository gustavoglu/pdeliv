using Microsoft.EntityFrameworkCore;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Infra.Data.Mapping;

namespace ProjectDeliv.Infra.Data.Contexts
{
    public class ContextSQL : DbContext
    {
        public DbSet<ProdutoGrupo> ProdutoGrupo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new ProdutoGrupoMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=project_deliv.db;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
