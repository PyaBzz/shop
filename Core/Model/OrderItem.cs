using System;

namespace Core
{
    public interface IDispatchItem
    {
        int ProductId { get; }
        int Quantity { get; }
    }
    public interface IOrderItem : IDispatchItem
    {
        new int ProductId { get; }
        new int Quantity { get; }
        string ProductName { get; }
        decimal UnitPrice { get; }
        decimal Amount { get; }
    }

    public class OrderItem : IOrderItem, IDispatchItem
    {
        public int ProductId { get; private set; }
        public string ProductName => throw new NotImplementedException();
        public decimal UnitPrice => throw new NotImplementedException();
        public int Quantity { get; private set; }
        public decimal Amount => throw new NotImplementedException();


        private OrderItem() { }
        // public int OrderId { get; private set; }

        // public OrderItem Create(int orderId, int productId, int quantity)
        // {
        //     var instance = new OrderItem
        //     {
        //         OrderId = orderId,
        //         ProductId = productId,
        //         Quantity = quantity
        //     };
        //     return instance;
        // }
    }
}
