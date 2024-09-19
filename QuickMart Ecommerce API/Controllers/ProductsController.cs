using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using QuickMart_Ecommerce_API.DTOs;

namespace QuickMart_Ecommerce_API.Controllers
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
        public async Task<IReadOnlyList<ProductDto>> GetProducts()
        {
            //var products = await _genericRepository.GetAllAsync();

            var spc = new ProductWithTypesAndBrandsSpecification();
            var products = await _genericRepository.GetAllWithSpecificationsAsync(spc);

            return _mapper.Map<IReadOnlyList<Product>, List<ProductDto>>(products);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            //var product = await _genericRepository.GetByIdAsync(id);

            var spc = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _genericRepository.GetEntityWithSpecificationsAsync(spc);

            return _mapper.Map<Product, ProductDto>(product);
        }
    }

}
