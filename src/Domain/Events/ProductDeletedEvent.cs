namespace Domain.Events
{
    public class ProductDeletedEvent
    {
        public Guid Id { get; set; }

        public ProductDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
