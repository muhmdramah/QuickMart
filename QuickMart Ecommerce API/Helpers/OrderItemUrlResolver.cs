using AutoMapper;
using Core.Entities.OrderAggregate;
using QuickMart_Ecommerce_API.DTOs.Order;

namespace QuickMart_Ecommerce_API.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrderd.PictureUrl))
                return _configuration["ApiUrl"] + source.ItemOrderd.PictureUrl;
            else
                return null;
        }
    }
}
