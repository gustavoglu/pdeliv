using ProjectDeliv.Domain.Validations.ProdutoClasss;

namespace ProjectDeliv.Domain.Commands.ProdutoClasss
{
    public class ProdutoClassAtualizacaoCommand : ProdutoClassCommand
    {
        public Guid Id { get; set; }

        public override bool isValid()
        {
            ValidationResult = new ProdutoClassAtualizacaoValidation().Validate(this);
            return base.isValid();
        }

    }
}
