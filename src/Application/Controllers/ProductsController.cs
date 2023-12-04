using Microsoft.AspNetCore.Mvc;
using Application.Services;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(string name, string description, decimal price, string category)
        {
            try
            {
                var result = await _productService.CreateProductAsync(name, description, price, category);

                if (!result)
                {
                    _logger.LogError($"Unable to save product.");
                    return BadRequest("Product was not saved.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }

            return Ok("Product saved.");
        }

        // GET: /Products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
    }
}
