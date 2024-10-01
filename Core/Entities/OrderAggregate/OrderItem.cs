namespace Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem() { }
        public OrderItem(ProductItemOrder itemOrderd, decimal price, int quantity)
        {
            ItemOrderd = itemOrderd;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrder ItemOrderd { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
