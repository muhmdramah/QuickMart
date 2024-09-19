using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IGenericRepository<ProductBrand> _genericRepository;

        public ProductBrandsController(IGenericRepository<ProductBrand> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _genericRepository.GetAllAsync();

            return productBrands;
        }

        [HttpGet("{id}")]
        public async Task<ProductBrand> GetProductBrand(int id)
        {
            var productBrand = await _genericRepository.GetByIdAsync(id);

            return productBrand;
        }
    }
}
