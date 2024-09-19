using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            var items = await _context.Set<T>()
                .ToListAsync();

            return items;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var item = await _context.Set<T>()
                .FindAsync(id);

            return item;
        }
    }
}
