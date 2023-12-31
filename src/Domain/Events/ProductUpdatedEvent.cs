﻿namespace Domain.Events
{
    public class ProductUpdatedEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string Category { get; }

        public ProductUpdatedEvent(Guid productId, string name, string description, decimal price, string category)
        {
            Id = productId;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }
    }
}
