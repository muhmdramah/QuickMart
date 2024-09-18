using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrand = await _context.ProductBrands.ToListAsync();
            return productBrand;
        }

        public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
        {
            var productBrand = await _context.ProductBrands.FindAsync(id);
            return productBrand;
        }
    }
}
