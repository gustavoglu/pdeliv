using System.ComponentModel.DataAnnotations;

namespace ProjectDeliv.Application.ViewModels.ProdutoClasss
{
    public class ProdutoClassFormInsercaoViewModel
    {
        [Required]
        public string Descricao { get; set; }
        public string? ImagemUrl { get; set; }
    }
}
