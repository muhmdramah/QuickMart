using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllWithSpecificationsAsync(ISpecification<T> specification);
        Task<T> GetEntityWithSpecificationsAsync(ISpecification<T> specification);
    }
}
