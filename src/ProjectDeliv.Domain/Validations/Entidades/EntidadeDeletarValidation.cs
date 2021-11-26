using FluentValidation;
using ProjectDeliv.Domain.Commands;
using ProjectDeliv.Domain.Commands.Entidades;

namespace ProjectDeliv.Domain.Validations.Entidades
{
    public class EntidadeDeletarValidation : AbstractValidator<EntidadeDeletarCommand>
    {
        public EntidadeDeletarValidation()
        {
            RuleFor(entidade => entidade.Id).NotEmpty().NotNull();
        }
    }
}
