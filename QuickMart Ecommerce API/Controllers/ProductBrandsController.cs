using API.DTOs.ProductBrand;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IGenericRepository<ProductBrand> _genericRepository;
        private readonly IMapper _mapper;

        public ProductBrandsController(IGenericRepository<ProductBrand> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _genericRepository.GetAllAsync();

            if (productBrands is null)
                return NotFound($"No Product Brands was found!");

            return Ok(productBrands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrand(int id)
        {
            var productBrand = await _genericRepository.GetByIdAsync(id);

            if (productBrand is null)
                return NotFound($"No Product Brand was found with id: {id}!");

            return Ok(productBrand);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductBrand([FromForm] AddProductBrandDto addProductBrandDto)
        {
            if (addProductBrandDto == null)
                return BadRequest("Product Brand must be not empty!");

            var productBrand = _mapper.Map<AddProductBrandDto, ProductBrand>(addProductBrandDto);

            await _genericRepository.AddAsync(productBrand);
            await _genericRepository.SaveChangesAsync();
            return Ok("Product Brand added successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductBrand(int id, [FromForm] UpdateProductBrandDto productBrandDto)
        {
            var productBrand = await _genericRepository.GetByIdAsync(id);

            if (productBrand is null)
                return NotFound($"No product brand was found with id: {id}");

            _mapper.Map(productBrandDto, productBrand);

            await _genericRepository.UpdateAsync(productBrand);
            await _genericRepository.SaveChangesAsync();

            return Ok("Product brand updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductBrand(int id)
        {
            var productBrand = await _genericRepository.GetByIdAsync(id);

            if (productBrand is not null)
            {
                await _genericRepository.DeleteAsync(productBrand);
                await _genericRepository.SaveChangesAsync();
                return Ok($"Product Brand with {id} deleted successfully!");
            }
            else
                return BadRequest("Product Brand is already not found!");
        }
    }
}
