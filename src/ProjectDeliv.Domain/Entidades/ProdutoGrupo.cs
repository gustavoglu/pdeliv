namespace ProjectDeliv.Domain.Entidades
{
    public class ProdutoGrupo : EntidadeBase
    {
        public ProdutoGrupo(){}

        public ProdutoGrupo(string descricao,Guid produtoClassId, List<ProdutoGrupoConfig>? configuracoes = null)
        {
            Descricao = descricao;
            ProdutoClassId = produtoClassId;
            Configuracoes = configuracoes ?? new List<ProdutoGrupoConfig>();
        }

        public string Descricao { get; set; }


        public Guid ProdutoClassId { get; set; }
        public ProdutoClass? ProdutoClass { get; set; }

        public List<ProdutoGrupoConfig>? Configuracoes  { get; set; }
    }
}
