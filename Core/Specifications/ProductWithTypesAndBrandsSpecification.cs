using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductSpecificationParameters parameters)
            : base(x =>
            (!parameters.TypeId.HasValue || x.ProductTypeId == parameters.TypeId) &&
            (!parameters.BrandId.HasValue || x.ProductBrandId == parameters.BrandId)
            )
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);

            AddOrderByAscending(p => p.Name);

            //ApplyPagination(parameters.PageSize * (parameters.PageIndex - 1), parameters.PageSize);
            ApplyPagination((parameters.PageIndex - 1) * parameters.PageSize, parameters.PageSize);


            if (!string.IsNullOrEmpty(parameters.Sort))
            {
                switch (parameters.Sort)
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
