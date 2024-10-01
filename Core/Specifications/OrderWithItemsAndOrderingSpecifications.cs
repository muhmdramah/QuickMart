using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderWithItemsAndOrderingSpecifications : BaseSpecification<Order>
    {
        public OrderWithItemsAndOrderingSpecifications(string email)
            : base(o => o.BuyerEmail.Equals(email))
        {
            AddIncludes(o => o.OrderItems);
            AddIncludes(o => o.DeliveryMethod);

            AddOrderByDescending(o => o.OrderDate);
        }

        public OrderWithItemsAndOrderingSpecifications(int id, string email)
            : base(o => o.Id.Equals(id) && o.BuyerEmail.Equals(email))
        {
            AddIncludes(o => o.OrderItems);
            AddIncludes(o => o.DeliveryMethod);
        }
    }
}
