namespace QuickMart_Ecommerce_API.DTOs.Order
{
    public class OrderDto
    {
        public string BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto ShippToAddress { get; set; }
    }
}