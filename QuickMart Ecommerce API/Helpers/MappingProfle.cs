using API.DTOs.Product;
using API.DTOs.ProductBrand;
using API.DTOs.ProductType;
using AutoMapper;
using Core.Entities;
using Core.Entities.OrderAggregate;
using QuickMart_Ecommerce_API.DTOs;
using QuickMart_Ecommerce_API.DTOs.Basket;
using QuickMart_Ecommerce_API.DTOs.Order;
using QuickMart_Ecommerce_API.Helpers;
using Address = Core.Identity.Address;

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

            CreateMap<AddressDto, Address>().ReverseMap();

            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<AddressDto, Address>();

            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrderd.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrderd.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrderd.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }


    }
}
