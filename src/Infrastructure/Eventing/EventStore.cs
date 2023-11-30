using CloudNative.CloudEvents;
using Infrastructure.Eventing.Interfaces;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Npgsql;
using Dapper;

namespace Infrastructure.Eventing
{
    public class EventStore : IEventStore
    {
        private readonly string _connectionString;

        public EventStore(IOptions<PostGresOptions> options)
        {
            _connectionString = options.Value.ConnectionString;            
        }

        public List<CloudEvent> GetEventsForAggregate(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void SaveEvents(Guid aggregateId, IEnumerable<CloudEvent> events, int expectedVersion)
        {
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    foreach (var eventItem in events)
                    {
                        var serializedEvent = JsonConvert.SerializeObject(eventItem);
                        var sql = "INSERT INTO events (AggregateId, EventData, EventType) VALUES (@AggregateId, @EventData, @EventType)";
                        connection.Execute(sql, new { AggregateId = aggregateId, EventData = serializedEvent, EventType = eventItem.Type });
                    }
                }
            }
        }
    }
}
