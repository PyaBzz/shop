using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public interface IOrder
    {
        int CustomerId { get; }
        IEnumerable<IOrderItem> Items { get; }
        bool Add(IOrderItem item);
        decimal Amount { get; }
        bool Submit();
    }

    public class Order : IOrder
    {
        public int CustomerId { get; private set; }
        public IEnumerable<IOrderItem> Items => items;
        public bool Add(IOrderItem item)
        {
            items.Add(item);
            return true;
        }
        public decimal Amount => Items.Sum(x => x.Amount);
        public bool Submit() => throw new NotImplementedException();

        private List<IOrderItem> items = new List<IOrderItem>();

        private Order() { }
        public static Order Create(int customerId)
        {
            return new Order
            {
                CustomerId = customerId,
            };
        }
    }
}
