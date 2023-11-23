using CloudNative.CloudEvents;

namespace Infrastructure.Eventing.Interfaces
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, IEnumerable<CloudEvent> events, int expectedVersion);
        List<CloudEvent> GetEventsForAggregate(Guid aggregateId);
    }
}
