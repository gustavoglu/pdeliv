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
        public virtual void Deletar(Guid id)
        {
            var entidade = this.ObterPorId(id);
            _context.Remove(entidade);
        }

        public virtual void Inserir(TEntidade entidade)
        {
            DbSet.Add(entidade);
        }

        public virtual TEntidade ObterPorId(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual List<TEntidade> ObterTodos()
        {
            return DbSet.ToList();
        }

        public virtual List<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> expression)
        {
            return DbSet.Where(expression).ToList();
        }

        public virtual void Atualizar(Guid id, TEntidade entidade)
        {
            DbSet.Update(entidade);
        }
    }
}
