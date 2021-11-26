using FluentValidation;
using ProjectDeliv.Domain.Commands.ProdutoClasss;

namespace ProjectDeliv.Domain.Validations.ProdutoClasss
{
    public abstract class ProdutoClassValidation<T> : AbstractValidator<T> where T : ProdutoClassCommand
    {
        protected void DescricaoValidation()
        {
            RuleFor(produtoClass => produtoClass.Descricao)
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
              .WithMessage("Obrigatório ter no máximo 100 caracteres");
        }

        protected void ImagemUrlValidation()
        {
            RuleFor(produtoClass => produtoClass.ImagemUrl).MaximumLength(500);
        }
    }
}
