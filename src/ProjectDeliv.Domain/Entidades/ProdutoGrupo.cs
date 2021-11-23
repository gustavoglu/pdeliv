namespace ProjectDeliv.Domain.Entidades
{
    public class ProdutoGrupo : EntidadeBase
    {
        public ProdutoGrupo(){}

        public ProdutoGrupo(string descricao, string imagemUrl = null)
        {
            Descricao = descricao;
            ImagemUrl = imagemUrl;
        }

        public string Descricao { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
