using ProjectDeliv.Domain.Commands.ProdutoClasss;

namespace ProjectDeliv.Domain.Validations.ProdutoClasss
{
    public class ProdutoClassInsercaoValidation : ProdutoClassValidation<ProdutoClassInsercaoCommand>
    {
        public ProdutoClassInsercaoValidation()
        {
            DescricaoValidation();
            ImagemUrlValidation();
        }
    }
}
