﻿using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QuickMart_Ecommerce_API.DTOs;

namespace QuickMart_Ecommerce_API.Controllers
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
        public async Task<IReadOnlyList<ProductBrandDto>> GetProductBrands()
        {
            var productBrands = await _genericRepository.GetAllAsync();

            return _mapper.Map<IReadOnlyList<ProductBrand>, List<ProductBrandDto>>(productBrands);
        }

        [HttpGet("{id}")]
        public async Task<ProductBrandDto> GetProductBrand(int id)
        {
            var productBrand = await _genericRepository.GetByIdAsync(id);

            return _mapper.Map<ProductBrand, ProductBrandDto>(productBrand);
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
