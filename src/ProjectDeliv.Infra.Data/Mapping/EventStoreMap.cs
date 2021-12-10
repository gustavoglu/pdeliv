using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDeliv.Domain.EventSourcing;

namespace ProjectDeliv.Infra.Data.Mapping
{
    public class EventStoreMap : IEntityTypeConfiguration<EventStore>
    {
        public void Configure(EntityTypeBuilder<EventStore> builder)
        {
            builder.Property(eventStore => eventStore.Type).HasMaxLength(250).IsRequired();
            builder.Property(eventStore => eventStore.UserId).HasMaxLength(250).IsRequired(false);
            builder.Property(eventStore => eventStore.AggregateId).IsRequired();
            builder.Property(eventStore => eventStore.Data).IsRequired(false);
        }
    }
}
