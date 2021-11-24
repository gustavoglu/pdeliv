using Microsoft.EntityFrameworkCore;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Infra.Data.Repositorios
{
    public class ProdutoGrupoRepositorio : Repositorio<ProdutoGrupo>, IProdutoGrupoRepositorio
    {
        public ProdutoGrupoRepositorio(ContextSQL context) : base(context)
        {
        }

        public override List<ProdutoGrupo> ObterTodos()
        {
            return this.DbSet.Include(produtoGrupo => produtoGrupo.Configuracoes)
                .ToList();
        }
    }
}
