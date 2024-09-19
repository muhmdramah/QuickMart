using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Implementations
{
    public class ProductTypeRepository : GenericRepository<ProductType>, IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
