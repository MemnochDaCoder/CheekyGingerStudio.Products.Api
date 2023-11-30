using Application.Factories.Interfaces;
using Domain.Models;

namespace Application.Factories
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct(string name, string description, decimal price, string category) => new Product(Guid.NewGuid(), name, description, price, category) { Name = name, Category = category, Description = description };
    }
}
