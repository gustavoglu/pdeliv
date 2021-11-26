using MediatR;

namespace ProjectDeliv.Domain.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        public List<DomainNotification> Notifications { get; set; }

        public DomainNotificationHandler()
        {
            Notifications = new List<DomainNotification>();
        }

        public bool HasNotification()
        {
            return Notifications.Any();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            Notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}
