using ProjectDeliv.Domain.Entidades;
using System.Linq.Expressions;

namespace ProjectDeliv.Domain.Interfaces
{
    public interface IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        List<TEntidade> ObterTodos();
        TEntidade ObterPorId(Guid id);
        List<TEntidade> Pesquisar(Expression<Func<TEntidade, bool>> expression);
        void Inserir(TEntidade entidade);
        void Atualizar(Guid id, TEntidade entidade);
        void Deletar(Guid id);
    }
}
