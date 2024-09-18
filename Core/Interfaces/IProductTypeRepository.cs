using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductTypeRepository
    {
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}
