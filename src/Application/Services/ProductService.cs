using Application.Factories.Interfaces;
using CloudNative.CloudEvents;
using Domain.Events;
using Infrastructure.Repositories.Interfaces;

namespace Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        private readonly IProductFactory _factory;

        public ProductService(IProductRepository repository, IProductFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public void CreateProduct(string name, string description, decimal price, string category)
        {
            var product = _factory.CreateProduct(name, description, price, category);
            var productCreatedEvent = new ProductCreatedEvent(product.Id, product.Name, product.Description, product.Price, product.Category);

            //Persist
            //_repository.SaveEvents(product.Id, new List<CloudEvent> { productCreatedEvent }, 0);
        }

        public void UpdateProduct(Guid id, string name, string description, decimal price, string category)
        {
            var product = _repository.GetById(id);
            // TODO: Update product and raise ProductUpdatedEvent...
        }

        public void DeleteProduct(Guid id)
        {
            // TODO: Raise ProductDeletedEvent...
        }
    }

}
