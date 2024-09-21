using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuickMart_Ecommerce_API.DTOs;

namespace QuickMart_Ecommerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IGenericRepository<ProductType> _genericRepository;
        private readonly IMapper _mapper;

        public ProductTypesController(IGenericRepository<ProductType> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductType(int id, [FromForm] UpdateProductTypeDto productTypeDto)
        {
            var productType = await _genericRepository.GetByIdAsync(id);

            if (productType is null)
                return NotFound($"No product type was found with id: {id}");

            _mapper.Map(productTypeDto, productType);

            await _genericRepository.UpdateAsync(productType);
            await _genericRepository.SaveChangesAsync();

            return Ok("Product type updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            var productType = await _genericRepository.GetByIdAsync(id);

            if (productType is not null)
            {
                await _genericRepository.DeleteAsync(productType);
                await _genericRepository.SaveChangesAsync();
                return Ok($"Product Type with {id} deleted successfully!");
            }
            else
                return BadRequest("Product Type is already not found!");
        }
    }
}
