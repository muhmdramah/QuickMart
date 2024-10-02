namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order() { }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail,
            Address shippingAddress, DeliveryMethod deliveryMethod, decimal subTotal, string paymentIntentId)
        {
            OrderItems = orderItems;
            BuyerEmail = buyerEmail;
            ShipToAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            SubTotal = subTotal;
            PaymentIntendId = paymentIntentId;
        }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public DeliveryMethod DeliveryMethod { get; set; }
        public Address ShipToAddress { get; set; }
        public string BuyerEmail { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntendId { get; set; }

        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }
    }
}
