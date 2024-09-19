﻿using AutoMapper;
using Core.Entities;
using QuickMart_Ecommerce_API.DTOs;

namespace QuickMart_Ecommerce_API.Helpers
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return _configuration["ApiUrl"] + source.PictureUrl;
            else
                return null;
        }
    }
}