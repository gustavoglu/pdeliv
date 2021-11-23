namespace ProjectDeliv.Domain.Entidades
{
    public class ProdutoGrupoConfig : EntidadeBase
    {

        public ProdutoGrupoConfig()
        {

        }

        public ProdutoGrupoConfig(string descricao, List<ProdutoGrupoConfigOpcao> opcoes = null)
        {
            Descricao = descricao;
            ProdutoGrupoConfigOpcoes = opcoes ?? new List<ProdutoGrupoConfigOpcao>();
        }

        public string Descricao { get; set; }


        public Guid ProdutoGrupoId { get; set; }
        public ProdutoGrupo ProdutoGrupo { get; set; }

        public List<ProdutoGrupoConfigOpcao> ProdutoGrupoConfigOpcoes { get; set; }
    }
}
