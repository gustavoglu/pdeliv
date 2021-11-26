using FluentValidation;
using ProjectDeliv.Domain.Commands.ProdutoClasss;

namespace ProjectDeliv.Domain.Validations.ProdutoClasss
{
    public class ProdutoClassAtualizacaoValidation : ProdutoClassValidation<ProdutoClassAtualizacaoCommand>
    {
        public ProdutoClassAtualizacaoValidation()
        {
            IdValidation();
            DescricaoValidation();
            ImagemUrlValidation();
        }

        private void IdValidation()
        {
            RuleFor(produtoClass => produtoClass.Id).NotNull().NotEmpty();
        }
    }
}
