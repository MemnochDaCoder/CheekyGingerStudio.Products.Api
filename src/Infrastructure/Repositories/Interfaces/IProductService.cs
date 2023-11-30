using Domain.Models;

namespace Application.Services
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<bool> SaveProductAsync(Product product);
        Task<bool> CreateProductAsync(string name, string description, decimal price, string category);
    }
}
