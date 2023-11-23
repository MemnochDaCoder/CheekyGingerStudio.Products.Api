using CloudNative.CloudEvents;

namespace Domain.Events
{
    public class EventConverter
    {
        public CloudEvent ConvertToCloudEvent(object domainEvent)
        {
            CloudEvent cloudEvent = new CloudEvent
            {
                Id = Guid.NewGuid().ToString(),
                Source = new Uri("urn:yourapp:source"),
                Time = DateTimeOffset.UtcNow,
                DataContentType = "application/json"
            };

            switch (domainEvent)
            {
                case ProductCreatedEvent productCreated:
                    cloudEvent.Type = "com.cheekygingerstudio-api.product.created";
                    cloudEvent.Data = productCreated;
                    break;
                case ProductUpdatedEvent productUpdated:
                    cloudEvent.Type = "com.cheekygingerstudio-api.product.updated";
                    cloudEvent.Data = productUpdated;
                    break;
                case ProductDeletedEvent productDeleted:
                    cloudEvent.Type = "com.cheekygingerstudio-api.product.deleted";
                    cloudEvent.Data = productDeleted;
                    break;
                default:
                    throw new ArgumentException("Unknown event type", nameof(domainEvent));
            }

            return cloudEvent;
        }
    }
}
