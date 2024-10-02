namespace QuickMart_Ecommerce_API.DTOs.Basket
{
    public class CustomerBasketDto
    {
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }

        public int? DeliveryMethodId { get; set; }
        public string ClientSercret { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
