using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationParameters parameters)
            : base(x =>
            (!parameters.TypeId.HasValue || x.ProductTypeId == parameters.TypeId) &&
            (!parameters.BrandId.HasValue || x.ProductBrandId == parameters.BrandId)
            )
        {
        }
    }
}
