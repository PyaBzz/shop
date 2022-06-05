namespace Core
{
    public interface IDispatchItem
    {
        int ProductId { get; }
        int Quantity { get; }
    }

    public interface IOrder
    {
        int CustomerId { get; }
        IOrderItem[] Items { get; }
        bool Add(IOrderItem item);
        decimal Amount { get; }
        bool Submit();
    }
}
