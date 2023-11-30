using Application.Factories.Interfaces;
using Domain.Events;
using Domain.Models;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IProductFactory _factory;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repository, IProductFactory factory, ILogger<ProductService> logger)
        {
            _repository = repository;
            _factory = factory;
            _logger = logger;
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<bool> CreateProductAsync(string name, string description, decimal price, string category)
        {
            var product = _factory.CreateProduct(name, description, price, category);
            var productCreatedEvent = new ProductCreatedEvent(product.Id, product.Name, product.Description, product.Price, product.Category);

            // Persist
            return await SaveProductAsync(product);
        }

        public async Task<bool> SaveProductAsync(Product product)
        {
            if (!ValidateProduct(product))
            {
                _logger.LogError($"Invalid product: {product}");
                throw new ArgumentException("Invalid product.");
            }

            // Persist
            return await _repository.SaveProductAsync(product);
        }

        private bool ValidateProduct(Product product)
        {
            return product != null &&
                   !string.IsNullOrWhiteSpace(product.Name) &&
                   !string.IsNullOrWhiteSpace(product.Description) &&
                   !string.IsNullOrWhiteSpace(product.Category) &&
                   product.Price > 0;
        }
    }
}
