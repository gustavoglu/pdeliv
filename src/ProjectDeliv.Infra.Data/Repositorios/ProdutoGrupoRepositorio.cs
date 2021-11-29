using Microsoft.EntityFrameworkCore;
using ProjectDeliv.Domain.Entidades;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Util;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Infra.Data.Repositorios
{
    public class ProdutoGrupoRepositorio : Repositorio<ProdutoGrupo>, IProdutoGrupoRepositorio
    {
        public ProdutoGrupoRepositorio(ContextSQL context) : base(context)
        {
        }

        public override Paginacao<ProdutoGrupo> ObterTodos(int pagina, int limite)
        {
            var total = Paginar(pagina, limite).LongCount();
            var data = Paginar(pagina, limite).Include(produtoGrupo => produtoGrupo.Configuracoes)
                .Include(produtoGrupo => produtoGrupo.ProdutoClass)
                .ToList();

            return new Paginacao<ProdutoGrupo>(data, limite, pagina, total);
        }
    }
}
