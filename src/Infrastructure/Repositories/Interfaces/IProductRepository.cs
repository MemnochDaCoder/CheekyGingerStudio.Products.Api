using Domain.Models;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<bool> SaveProductAsync(Product product);
    }
}
