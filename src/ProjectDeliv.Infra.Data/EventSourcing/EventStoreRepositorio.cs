using Microsoft.EntityFrameworkCore;
using ProjectDeliv.Domain.EventSourcing;
using ProjectDeliv.Infra.Data.Contexts;

namespace ProjectDeliv.Infra.Data.EventSourcing
{
    public class EventStoreRepositorio : IEventStoreRepositorio
    {
        private readonly ContextSQL _context;
        protected readonly DbSet<EventStore> DbSet;
        public EventStoreRepositorio(ContextSQL context)
        {
            _context = context;
            DbSet = _context.EventStore;
        }
        public IEnumerable<EventStore> GetByAggregateId(Guid aggregateId)
        {
            return DbSet.Where(eventStore => eventStore.AggregateId == aggregateId).ToList();
        }

        public void Save(EventStore eventStore)
        {
            DbSet.Add(eventStore);
        }
    }
}
