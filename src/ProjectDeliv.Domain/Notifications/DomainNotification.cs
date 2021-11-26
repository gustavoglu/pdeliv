using MediatR;

namespace ProjectDeliv.Domain.Notifications
{
    public class DomainNotification : INotification
    {
        public DomainNotification(string type, string value)
        {
            Id = Guid.NewGuid();
            Version = 1;
            Type = type;
            Value = value;
        }

        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
