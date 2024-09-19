using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Implementations
{
    public class ProductBrandRepository : GenericRepository<ProductBrand>, IProductBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductBrandRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
