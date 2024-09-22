namespace QuickMart_Ecommerce_API.DTOs.Product
{
    public class AddProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
    }
}