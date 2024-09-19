using Core.Interfaces;
using Core.Specifications;
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

        public async Task<IReadOnlyList<T>> GetAllWithSpecificationsAsync(ISpecification<T> specification)
        {
            var entities = await ApplySpecification(specification).ToListAsync();
            return entities;
        }

        public async Task<T> GetEntityWithSpecificationsAsync(ISpecification<T> specification)
        {
            var entity = await ApplySpecification(specification).FirstOrDefaultAsync();
            return entity;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}
