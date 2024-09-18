using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _context.ProductTypes.ToListAsync();
            return productTypes;
        }

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            return productType;
        }
    }
}
