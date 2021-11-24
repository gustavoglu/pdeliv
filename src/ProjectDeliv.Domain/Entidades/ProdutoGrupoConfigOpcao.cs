namespace ProjectDeliv.Domain.Entidades
{
    public class ProdutoGrupoConfigOpcao : EntidadeBase
    {
        public ProdutoGrupoConfigOpcao()
        {

        }
        public ProdutoGrupoConfigOpcao(int codigo, string descricao, double preco = 0)
        {
            Codigo = codigo;
            Descricao = descricao;
            Preco = preco;
        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public List<ProdutoGrupoConfig>? ProdutoGrupoConfigs { get; set; }


    }
}
