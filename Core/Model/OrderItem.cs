using System;
using System.Threading.Tasks;

namespace Core
{
    public class OrderItem : Item, IOrderItem
    {
        // ==============================  Interface  ==============================
        public int? Id { get; private set; }
        public int? OrderId { get; private set; }
        public int ProductId { get; private set; }
        public string ProductName => throw new NotImplementedException();
        public decimal UnitPrice => throw new NotImplementedException();
        public int Quantity { get; private set; }
        public decimal Amount => throw new NotImplementedException();

        // ==============================  State  ==============================

        public class State
        {
            public int? OrderId { get; set; }
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        // ==============================  Factory  ==============================
        private OrderItem() { }

        public static class Factory //todo: unit test the factory
        {
            public static OrderItem Create(int? orderId, int productId, int quantity) =>
                new OrderItem
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity
                };

            public static async Task<OrderItem> Retrieve(IOrderItemRepository r, int id)
            {
                var state = await r.Get(id);
                return Create(state);
            }

            private static OrderItem Create(State state) =>
                new OrderItem()
                {
                    Id = state.Id,
                    OrderId = state.OrderId,
                    ProductId = state.ProductId,
                    Quantity = state.Quantity
                };
        }
    }

    public interface IOrderItemRepository
    {
        Task<int> Save(OrderItem item);
        Task<OrderItem.State> Get(int id);
    }
}
