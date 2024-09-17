using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();

            return products;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            var product = await _productRepository.GetProductsByIdAsync(id);

            return product;
        }
    }

}
