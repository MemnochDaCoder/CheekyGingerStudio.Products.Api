using Application.Factories.Interfaces;
using Domain.Models;

namespace Application.Factories
{
    public class ProductFactory : IProductFactory
    {
        public Product CreateProduct(string name, string description, decimal price, string category)
        {
            throw new NotImplementedException();
        }
    }
}
