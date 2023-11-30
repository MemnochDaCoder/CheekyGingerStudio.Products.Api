using Domain.Models;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task CreateProductAsync(Product aggregate);
        Task<bool> SaveProductAsync(Product product);
    }
}
