using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        Task SaveChangesAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecificationsAsync(ISpecification<T> specification);
        Task<T> GetEntityWithSpecificationsAsync(ISpecification<T> specification);
    }
}
