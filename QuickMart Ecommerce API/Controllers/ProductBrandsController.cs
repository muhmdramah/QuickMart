using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public ProductBrandsController(IProductBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _productBrandRepository.GetProductBrandsAsync();

            return productBrands;
        }

        [HttpGet("{id}")]
        public async Task<ProductBrand> GetProductBrand(int id)
        {
            var productBrand = await _productBrandRepository.GetProductBrandByIdAsync(id);

            return productBrand;
        }
    }
}
