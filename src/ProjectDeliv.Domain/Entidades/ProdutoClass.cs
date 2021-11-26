namespace ProjectDeliv.Domain.Entidades
{
    public class ProdutoClass : EntidadeBase
    {
        public ProdutoClass()
        {

        }

        public ProdutoClass(string descricao, string? imagemUrl = null, List<ProdutoGrupo>? grupos = null)
        {
            Descricao = descricao;
            ImagemUrl = imagemUrl;
            Grupos = grupos;
        }

        public string Descricao { get; set; }
        public string? ImagemUrl { get; set; }


        public List<ProdutoGrupo>? Grupos { get; set; }
    }
}
