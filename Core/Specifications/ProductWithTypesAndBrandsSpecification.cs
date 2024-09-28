using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(string sort, int? typeId, int? brandId)
            : base(x =>
            !typeId.HasValue || x.ProductTypeId == typeId &&
            !brandId.HasValue || x.ProductBrandId == brandId)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);

            AddOrderByAscending(p => p.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "Price Ascending":
                        AddOrderByAscending(p => p.Price);
                        break;
                    case "Price Descending":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderByAscending(p => p.Name);
                        break;
                }
            }
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);
        }
    }
}
