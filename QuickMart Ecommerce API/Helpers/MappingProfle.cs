using AutoMapper;
using Core.Entities;
using API.DTOs.Product;
using API.DTOs.ProductBrand;
using API.DTOs.ProductType;

namespace API.Helpers
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
