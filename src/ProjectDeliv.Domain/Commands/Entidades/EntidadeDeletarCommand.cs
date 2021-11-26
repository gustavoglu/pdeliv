using ProjectDeliv.Domain.Validations.Entidades;

namespace ProjectDeliv.Domain.Commands.Entidades
{
    public class EntidadeDeletarCommand : CommandBase
    {
        public Guid Id { get; set; }

        public override bool isValid()
        {
            ValidationResult = new EntidadeDeletarValidation().Validate(this);
            return base.isValid();
        }
    }
}
