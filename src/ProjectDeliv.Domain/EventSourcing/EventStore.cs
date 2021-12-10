using Newtonsoft.Json;

namespace ProjectDeliv.Domain.EventSourcing
{
    public class EventStore
    {
        public EventStore(Guid aggregateId, string type, string data)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
            Type = type;
            Data = data;
        }

        public EventStore(Guid aggregateId, string type, object? data = null)
        {
            Id = Guid.NewGuid();
            AggregateId = aggregateId;
            Timestamp = DateTime.Now;
            Type = type;

            if(data != null)
                Data = JsonConvert.SerializeObject(data);
        }

        public Guid Id { get; set; }
        public Guid AggregateId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
        public Guid? UserId { get; set; }
        public string? Data { get; set; }
    }
}
