using Domain.Models;

namespace Infrastructure.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(Guid id);
        void Save(Product aggregate);
    }
}
