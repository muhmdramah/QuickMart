namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order() { }

        public Order(DeliveryMethod deliveryMethod, Address shipToAddress, string buyerEmail,
            IReadOnlyList<OrderItem> orderItems, decimal subTotal)
        {
            DeliveryMethod = deliveryMethod;
            ShipToAddress = shipToAddress;
            BuyerEmail = buyerEmail;
            OrderItems = orderItems;
            SubTotal = subTotal;
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
