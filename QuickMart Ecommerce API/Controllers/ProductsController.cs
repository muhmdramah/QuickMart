using API.DTOs.Product;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using QuickMart_Ecommerce_API.Helpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> genericRepository,
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProducts(
            [FromQuery] ProductSpecificationParameters parameters)
        {
            var specification = new ProductWithTypesAndBrandsSpecification(parameters);
            var countSpecification = new ProductWithFiltersForCountSpecification(parameters);

            var totalItems = await _genericRepository.CountAsync(countSpecification);

            var products = await _genericRepository.GetAllWithSpecificationsAsync(specification);

            if (products is null)
                return NotFound($"No Products was found!");

            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            var result = new Pagination<ProductDto>(parameters.PageIndex, parameters.PageSize, totalItems, data);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id)
        {
            //var product = await _genericRepository.GetByIdAsync(id);

            var spc = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _genericRepository.GetEntityWithSpecificationsAsync(spc);

            if (product is null)
                return NotFound($"No Product was found with id: {id}!");

            var productToReturn = _mapper.Map<Product, ProductDto>(product);

            return Ok(productToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm] AddProductDto addProductDto)
        {
            if (addProductDto == null)
                return BadRequest("Product must be not empty!");

            var product = _mapper.Map<AddProductDto, Product>(addProductDto);

            await _genericRepository.AddAsync(product);
            await _genericRepository.SaveChangesAsync();
            return Ok("Product added successfully!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] UpdateProductDto updateProductDto)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product is null)
                return NotFound($"No product was found with id: {id}");

            _mapper.Map(updateProductDto, product);

            await _genericRepository.UpdateAsync(product);
            await _genericRepository.SaveChangesAsync();

            return Ok("Product updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _genericRepository.GetByIdAsync(id);

            if (product is not null)
            {
                await _genericRepository.DeleteAsync(product);
                await _genericRepository.SaveChangesAsync();
                return Ok($"Product with {id} deleted successfully!");
            }
            else
                return BadRequest("Product is already not found!");
        }
    }

}
