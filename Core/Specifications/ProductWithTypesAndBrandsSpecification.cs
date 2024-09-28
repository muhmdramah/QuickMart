using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(string sort)
        {
            AddIncludes(p => p.ProductType);
            AddIncludes(p => p.ProductBrand);

            AddOrderByAscending(p => p.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "PriceAscending":
                        AddOrderByAscending(p => p.Price);
                        break;
                    case "PriceDescending":
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
