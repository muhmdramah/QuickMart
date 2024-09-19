using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _genericRepository;

        public ProductTypesController(IGenericRepository<ProductType> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IReadOnlyList<ProductType>> GetProductTypes()
        {
            var productTypes = await _genericRepository.GetAllAsync();

            return productTypes;
        }

        [HttpGet("{id}")]
        public async Task<ProductType> GetProductType(int id)
        {
            var productType = await _genericRepository.GetByIdAsync(id);

            return productType;
        }
    }
}
