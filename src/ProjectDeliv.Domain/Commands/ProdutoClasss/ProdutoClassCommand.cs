namespace ProjectDeliv.Domain.Commands.ProdutoClasss
{
    public abstract class ProdutoClassCommand : CommandBase
    {
        public string Descricao { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
