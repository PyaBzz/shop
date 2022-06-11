using System.Threading.Tasks;

namespace Core
{
    public interface IDispatchItem
    {
        int ProductId { get; }
        int Quantity { get; }
    }

    public interface IOrder
    {
        int? Id { get; }
        int CustomerId { get; }
        IOrderItem[] Items { get; }
        bool Add(IOrderItem item);
        decimal Amount { get; }
        Task<int> Submit(IOrderRepository r);
    }
}
