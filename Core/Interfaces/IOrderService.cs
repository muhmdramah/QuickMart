using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrdersByIdAsync(int id, string buyerEmail);
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketIt, Address shippingAddress);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
