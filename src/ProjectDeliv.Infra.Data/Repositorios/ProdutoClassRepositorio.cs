using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Infra.Data.Repositorios
{
    public class ProdutoClassRepositorio : Repositorio<ProdutoClass>, IProdutoClassRepositorio
    {
        public ProdutoClassRepositorio(ContextSQL context) : base(context)
        {
        }
    }
}
