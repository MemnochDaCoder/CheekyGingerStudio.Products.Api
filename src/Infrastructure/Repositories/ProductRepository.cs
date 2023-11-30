using Domain.Models;
using Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CheekyGingerStudioDbContext _context;

        public ProductRepository(CheekyGingerStudioDbContext context)
        {
            _context = context;
        }

        public Task CreateProductAsync(Product aggregate)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id) ?? new Product(Guid.Empty, null!, null!, decimal.Zero, null!) { Name = null!, Category = null!, Description = null!};
        }

        public async Task<bool> SaveProductAsync(Product product)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                _context.Products.Add(product);
            }
            else
            {
                _context.Entry(existingProduct).CurrentValues.SetValues(product);
            }

            var saveResult = await _context.SaveChangesAsync();
            return saveResult > 0;
        }
    }
}
