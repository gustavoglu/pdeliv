namespace ProjectDeliv.Domain.Entidades
{
    public class ProdutoGrupo : EntidadeBase
    {
        public ProdutoGrupo(){}

        public ProdutoGrupo(string descricao, string imagemUrl = null, List<ProdutoGrupoConfig> configuracoes = null)
        {
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Configuracoes = configuracoes ?? new List<ProdutoGrupoConfig>();
        }

        public string Descricao { get; set; }
        public string? ImagemUrl { get; set; }


        public List<ProdutoGrupoConfig> Configuracoes  { get; set; }
    }
}
