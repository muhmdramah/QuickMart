using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
