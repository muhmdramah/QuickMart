using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypesController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var productTypes = await _productTypeRepository.GetProductTypesAsync();

            return productTypes;
        }

        [HttpGet("{id}")]
        public async Task<ProductType> GetProductType(int id)
        {
            var productType = await _productTypeRepository.GetProductTypeByIdAsync(id);

            return productType;
        }
    }
}
