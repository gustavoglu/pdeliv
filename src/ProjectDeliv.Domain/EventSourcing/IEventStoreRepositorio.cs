namespace ProjectDeliv.Domain.EventSourcing
{
    public interface IEventStoreRepositorio
    {
        void Save(EventStore eventStore);
        IEnumerable<EventStore> GetByAggregateId(Guid aggregateId);
    }
}
