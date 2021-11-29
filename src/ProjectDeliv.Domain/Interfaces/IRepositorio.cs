using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Util;
using System.Linq.Expressions;

namespace ProjectDeliv.Domain.Interfaces
{
    public interface IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        Paginacao<TEntidade> ObterTodos(int pagina, int limite);
        TEntidade ObterPorId(Guid id);
        Paginacao<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> expression, int pagina, int limite);
        long Contar(Expression<Func<TEntidade, bool>>? expression = null);
        void Inserir(TEntidade entidade);
        void Atualizar(Guid id, TEntidade entidade);
        void Deletar(Guid id);
    }
}
