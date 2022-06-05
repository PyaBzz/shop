using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public interface IOrder
    {
        int CustomerId { get; }
        IOrderItem[] Items { get; }
        bool Add(IOrderItem item);
        decimal Amount { get; }
        bool Submit();
    }

    public class Order : IOrder
    {
        public int CustomerId { get; private set; }
        public IOrderItem[] Items => items.Values.ToArray();
        public bool Add(IOrderItem item)
        {
            if (items.ContainsKey(item.ProductId))
                return false;
            items.Add(item.ProductId, item);
            return true;
        }
        public decimal Amount => Items.Sum(x => x.Amount);
        public bool Submit() => throw new NotImplementedException();

        private Dictionary<int, IOrderItem> items = new Dictionary<int, IOrderItem>();

        private Order() { }
        public static Order Create(int customerId)
        {
            return new Order
            {
                CustomerId = customerId,
            };
        }
    }

    public interface IOrderItem : IDispatchItem
    {
        new int ProductId { get; }
        new int Quantity { get; }
        string ProductName { get; }
        decimal UnitPrice { get; }
        decimal Amount { get; }
    }
}
