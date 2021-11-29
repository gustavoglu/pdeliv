using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Infra.Data.Mapping;
using System.Linq;

namespace ProjectDeliv.Infra.Data.Contexts
{
    public class ContextSQL : DbContext
    {
        public DbSet<ProdutoGrupo> ProdutoGrupo { get; set; }
        public DbSet<ProdutoGrupoConfig> ProdutoGrupoConfig { get; set; }
        public DbSet<ProdutoGrupoConfigOpcao> ProdutoGrupoConfigOpcao { get; set; }
        public DbSet<ProdutoClass> ProdutoClass { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProdutoGrupoMap());
            modelBuilder.ApplyConfiguration(new ProdutoGrupoConfigMap());
            modelBuilder.ApplyConfiguration(new ProdutoGrupoConfigOpcaoMap());
            modelBuilder.ApplyConfiguration(new ProdutoClassMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=project_deliv.db;");
            base.OnConfiguring(optionsBuilder);
        }


        public override int SaveChanges()
        {
            var entryEntidades = this.ChangeTracker.Entries().Where(entry => entry.Entity is EntidadeBase).ToList();

            var insercoes = entryEntidades.Where(entityEntry => entityEntry.State == EntityState.Added).ToList();
            var atualizacoes = entryEntidades.Where(entityEntry => entityEntry.State == EntityState.Modified).ToList();
            var delecoes = entryEntidades.Where(entityEntry => entityEntry.State == EntityState.Deleted).ToList();

            AdicionarCamposEmInsercoes(insercoes);
            AdicionarCamposEmAtualizacoes(atualizacoes);
            AdicionarCamposEmDelecoes(delecoes);

            return base.SaveChanges();
        }

        private void AdicionarCamposEmInsercoes(List<EntityEntry> insersoes)
        {
            if (!insersoes.Any()) return;


            foreach (var entityEntry in insersoes)
            {
                var entidade = entityEntry.Entity as EntidadeBase;
                entidade.InseridoEm = DateTime.Now;
            }
        }

        private void AdicionarCamposEmAtualizacoes(List<EntityEntry> atualizacoes)
        {
            if (!atualizacoes.Any()) return;


            foreach (var entityEntry in atualizacoes)
            {
                entityEntry.Property("InseridoEm").IsModified = false;
                entityEntry.Property("InseridoPor").IsModified = false;

                entityEntry.Property("DeletadoEm").IsModified = false;
                entityEntry.Property("DeletadoPor").IsModified = false;

                var entidade = entityEntry.Entity as EntidadeBase;
                entidade.AtualizadoEm = DateTime.Now;
            }
        }

        private void AdicionarCamposEmDelecoes(List<EntityEntry> delecoes)
        {
            if (!delecoes.Any()) return;


            foreach (var entityEntry in delecoes)
            {
                entityEntry.Property("AtualizadoEm").IsModified = false;
                entityEntry.Property("AtualizadoPor").IsModified = false;

                entityEntry.Property("InseridoEm").IsModified = false;
                entityEntry.Property("InseridoPor").IsModified = false;

                var entidade = entityEntry.Entity as EntidadeBase;
                entidade.DeletadoEm = DateTime.Now;
                entidade.Deletado = true;
                entityEntry.State = EntityState.Modified;
            }
        }

    }
}
