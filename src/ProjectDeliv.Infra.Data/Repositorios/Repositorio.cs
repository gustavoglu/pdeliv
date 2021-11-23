using Microsoft.EntityFrameworkCore;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Infra.Data.Contexts;
using System.Linq.Expressions;

namespace ProjectDeliv.Infra.Data.Repositorios
{
    public class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        private readonly ContextSQL _context;
        protected DbSet<TEntidade> DbSet;
        public Repositorio(ContextSQL context)
        {
            _context = context;
            DbSet = _context.Set<TEntidade>();
        }
        public void Deletar(Guid id)
        {
            var entidade = this.ObterPorId(id);
            entidade.Deletado = true;
            entidade.DeletadoEm = DateTime.Now;

            Atualizar(id, entidade);
        }

        public void Inserir(TEntidade entidade)
        {
            entidade.InseridoEm = DateTime.Now;
            DbSet.Add(entidade);
        }

        public TEntidade ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public List<TEntidade> ObterTodos()
        {
            return DbSet.ToList();
        }

        public List<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public void Atualizar(Guid id, TEntidade entidade)
        {
            entidade.AtualizadoEm = DateTime.Now;
            DbSet.Update(entidade);
        }
    }
}
