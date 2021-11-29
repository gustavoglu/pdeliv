using Microsoft.EntityFrameworkCore;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Util;
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

        protected IQueryable<TEntidade> Paginar(int pagina, int limite)
        {
            return DbSet.Skip((pagina - 1) * limite).Take(limite);
        }

        protected long Contar(IQueryable<TEntidade> query)
        {
            return query.LongCount();
        }


        public virtual Paginacao<TEntidade> ObterTodos(int pagina, int limite)
        {
            var total = Contar(DbSet);
            var data = Paginar(pagina, limite).ToList();

            return new Paginacao<TEntidade>(data, limite, pagina, total);
        }

        public virtual Paginacao<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> expression, int pagina, int limite)
        {
            var data = Paginar(pagina, limite).Where(expression).ToList();
            long total = Contar(expression);

            return new Paginacao<TEntidade>(data, limite, pagina, total);
        }

        public virtual void Atualizar(Guid id, TEntidade entidade)
        {
            DbSet.Update(entidade);
        }


        public virtual long Contar(Expression<Func<TEntidade, bool>>? expression = null)
        {
            if (expression == null) return DbSet.LongCount();
            return DbSet.Where(expression).LongCount();
        }
    }
}
