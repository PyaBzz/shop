using System;
using System.Linq;
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

        public class Factory : IOrderItemFactory //todo: unit test the factory
        {
            private IOrderItemRepository repo;
            public Factory(IOrderItemRepository r) => repo = r;
            public OrderItem Create(int? orderId, int productId, int quantity) =>
                new OrderItem()
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Quantity = quantity,
                };

            public async Task<OrderItem> Retrieve(int id)
            {
                var state = await repo.Get(id);
                return Create(state);
            }
            public async Task<OrderItem[]> RetrieveForOrder(int orderId)
            {
                var states = await repo.RetrieveForOrder(orderId);
                return states.Select(x => Create(x)).ToArray();
            }
            private OrderItem Create(State state) =>
                new OrderItem()
                {
                    Id = state.Id,
                    OrderId = state.OrderId,
                    ProductId = state.ProductId,
                    Quantity = state.Quantity
                };
        }
    }

    public interface IOrderItemFactory
    {
        OrderItem Create(int? orderId, int productId, int quantity);
        Task<OrderItem> Retrieve(int id);
        Task<OrderItem[]> RetrieveForOrder(int orderId);
    }

    public interface IOrderItemRepository
    {
        Task<int> Save(OrderItem item);
        Task<OrderItem.State> Get(int id);
        Task<OrderItem.State[]> RetrieveForOrder(int orderId);
    }
}
