using System.Threading.Tasks;

namespace Core
{
    public interface Item
    {
        int? OrderId { get; }
        int ProductId { get; }
        int Quantity { get; }
    }

    public interface IOrder
    {
        int? Id { get; }
        int CustomerId { get; }
        Task<IOrderItem[]> GetItems();
        bool Add(Item item);
        decimal Amount { get; }
        Task<int> Stage(IOrderRepository r);
    }
}
