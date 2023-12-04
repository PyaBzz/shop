namespace Core;

public interface IOrderItemRepo
{
    Task<IEnumerable<int>> Save(IEnumerable<OrderItem> items);
    Task<IEnumerable<OrderItem>> Get(int orderId);
}
