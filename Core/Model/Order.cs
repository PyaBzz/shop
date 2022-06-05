using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Order : IPersistable, IOrder
    {
        public int? Id { get; private set; }
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

        public async Task<int> Submit() => await repo.Save(this);

        private readonly Dictionary<int, IOrderItem> items = new Dictionary<int, IOrderItem>();
        private readonly IOrderRepository repo;

        private Order(IOrderRepository r) => repo = r;
        public static Order Create(IOrderRepository r, int customerId)
        {
            return new Order(r)
            {
                CustomerId = customerId
            };
        }
    }

    public interface IOrderItem
    {
        int ProductId { get; }
        int Quantity { get; }
        string ProductName { get; }
        decimal UnitPrice { get; }
        decimal Amount { get; }
    }

    public interface IOrderRepository
    {
        Task<int> Save(Order order);
        Task<Order> Get(int id);
    }
}
