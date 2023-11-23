using Domain.Models;

namespace Application.Factories.Interfaces
{
    public interface IProductFactory
    {
        Product CreateProduct(string name, string description, decimal price, string category);
    }
}
