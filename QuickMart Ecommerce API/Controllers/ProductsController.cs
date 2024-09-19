using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _genericRepository;

        public ProductsController(IGenericRepository<Product> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
            //var products = await _genericRepository.GetAllAsync();

            var spc = new ProductWithTypesAndBrandsSpecification();
            var products = await _genericRepository.GetAllWithSpecificationsAsync(spc);

            return products;
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            //var product = await _genericRepository.GetByIdAsync(id);

            var spc = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _genericRepository.GetEntityWithSpecificationsAsync(spc);

            return product;
        }
    }

}
