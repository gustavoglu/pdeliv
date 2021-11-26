using ProjectDeliv.Domain.Validations.ProdutoClasss;

namespace ProjectDeliv.Domain.Commands.ProdutoClasss
{
    public class ProdutoClassInsercaoCommand : ProdutoClassCommand
    {
        public override bool isValid()
        {
            ValidationResult = new ProdutoClassInsercaoValidation().Validate(this);
            return base.isValid();
        }
    }
}
