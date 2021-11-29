using AutoMapper;
using MediatR;
using ProjectDeliv.Domain.Commands;
using ProjectDeliv.Domain.Interfaces;
using ProjectDeliv.Domain.Notifications;

namespace ProjectDeliv.Domain.CommandHandlers
{
    public abstract class CommandHandlerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _uow;
        protected readonly IMapper Mapper;

        protected CommandHandlerBase(INotificationHandler<DomainNotification> notifications, IMediator mediator, IUnitOfWork uow, IMapper mapper)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
            _uow = uow;
            Mapper = mapper;
        }

        protected bool Commit()
        {
            var commit = _uow.SaveChanges();
            if (commit) return true;
            _mediator.Publish(new DomainNotification("Database", "Algo deu errado ao tentar atualizar o banco de dados"));
            return false;
        }

        protected bool HasNotification()
        {
            return _notifications.HasNotification();
        }

        protected bool CommandIsValid<T>(T command) where T : CommandBase
        {
            if (command.isValid()) return true;

            var domainNotifications = command.ValidationResult.Errors.Select(error => new DomainNotification("Validation", error.ErrorMessage));

            foreach (var domainNotification in domainNotifications) _mediator.Publish(domainNotification);

            return false;
        }
    }
}
