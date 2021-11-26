using FluentValidation.Results;
using MediatR;

namespace ProjectDeliv.Domain.Commands
{
    public abstract class CommandBase : IRequest
    {
        public ValidationResult ValidationResult { get; set; }

        public CommandBase()
        {
            ValidationResult = new ValidationResult();
        }
        public virtual bool isValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
