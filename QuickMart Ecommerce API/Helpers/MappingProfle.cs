using AutoMapper;
using Core.Entities;
using QuickMart_Ecommerce_API.DTOs.Product;
using QuickMart_Ecommerce_API.DTOs.ProductBrand;
using QuickMart_Ecommerce_API.DTOs.ProductType;

namespace QuickMart_Ecommerce_API.Helpers
{
    public class MappingProfle : Profile
    {
        public MappingProfle()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductBrand, output => output.MapFrom(src => src.ProductBrand.Name))
                .ForMember(dest => dest.ProductType, output => output.MapFrom(src => src.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, output => output.MapFrom<ProductImageUrlResolver>());

            CreateMap<UpdateProductDto, Product>();
            CreateMap<UpdateProductBrandDto, ProductBrand>();
            CreateMap<UpdateProductTypeDto, ProductType>();

            CreateMap<AddProductDto, Product>();
            CreateMap<AddProductTypeDto, ProductType>();
            CreateMap<AddProductBrandDto, ProductBrand>();
        }


    }
}
