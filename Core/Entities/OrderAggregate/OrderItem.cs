namespace Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem() { }
        public OrderItem(ProductItemOrder productItem, decimal price, int quantity)
        {
            ProductItem = productItem;
            Price = price;
            Quantity = quantity;
        }

        public ProductItemOrder ProductItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
