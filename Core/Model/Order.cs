using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
    }

    public class Order : IOrder
    {
        // ==============================  Interface  ==============================

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

        public async Task<int> Submit(IOrderRepository r)
        {
            Id = await r.Save(this);
            return Id.Value;
        }

        // ==============================  State  ==============================

        private readonly Dictionary<int, IOrderItem> items = new Dictionary<int, IOrderItem>();

        // ==============================  Factory  ==============================

        private Order() { }

        public static class Factory //todo: unit test the factory
        {
            public static Order Create(int customerId) =>
                new Order() { CustomerId = customerId };

            public static async Task<Order> Retrieve(IOrderRepository r, int id)
            {
                var dto = await r.Get(id);
                return Create(dto);
            }

            private static Order Create(OrderDto dto) =>
                new Order() { Id = dto.Id, CustomerId = dto.CustomerId };
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
        Task<OrderDto> Get(int id);
    }
}
