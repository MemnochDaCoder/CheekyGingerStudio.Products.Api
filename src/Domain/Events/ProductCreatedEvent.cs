﻿using Domain.Models;

namespace Domain.Events
{
    public class ProductCreatedEvent
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public string Category { get; }

        public ProductCreatedEvent(Guid productId, string name, string description, decimal price, string category)
        {
            Id = productId;
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public ProductCreatedEvent(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Category = product.Category;
        }
    }
}
