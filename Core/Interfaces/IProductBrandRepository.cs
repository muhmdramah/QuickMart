using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductBrandRepository
    {
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<ProductBrand> GetProductBrandByIdAsync(int id);
    }
}
