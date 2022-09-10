using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    // public class Order : IOrder
    // {
    //     // ==============================  Interface  ==============================

    //     public int? Id { get; private set; }
    //     public int CustomerId { get; private set; }
    //     public async Task<IOrderItem[]> GetItems() => await itemFactory.RetrieveForOrder(this.Id.Value);
    //     public bool Add(Item item)
    //     {
    //         throw new NotImplementedException();
    //     }
    //     public decimal Amount => throw new NotImplementedException();

    //     public async Task<int> Stage(IOrderRepository r)
    //     {
    //         Id = await r.Save(this);
    //         return Id.Value;
    //     }

    //     // ==============================  State  ==============================

    //     public class State
    //     {
    //         public int Id { get; set; }
    //         public int CustomerId { get; set; }
    //     }

    //     private IOrderItemFactory itemFactory;

    //     // ==============================  Factory  ==============================

    //     private Order(IOrderItemFactory itemFac) { itemFactory = itemFac; }

    //     public class Factory : IOrderFactory//todo: make the factory non-static and unit test it
    //     {
    //         private IOrderRepository repo;
    //         private IOrderItemFactory itemFactory;
    //         public Factory(IOrderRepository r, IOrderItemFactory itemFac)
    //         {
    //             repo = r;
    //             itemFactory = itemFac;
    //         }
    //         public Order Create(int customerId) => new Order(itemFactory) { CustomerId = customerId };

    //         public async Task<Order> Retrieve(int id)
    //         {
    //             var state = await repo.Get(id);
    //             return Create(state);
    //         }

    //         private Order Create(State state) =>
    //             new Order(itemFactory) { Id = state.Id, CustomerId = state.CustomerId };
    //     }
    // }

    // public interface IOrderFactory
    // {
    //     Order Create(int customerId);
    //     Task<Order> Retrieve(int id);
    // }
    // public interface IOrderRepository
    // {
    //     Task<int> Save(Order order);
    //     Task<Order.State> Get(int id);
    // }

    public interface IOrderItem
    {
        int? Id { get; }
        IProduct Product { get; }
        int Quantity { get; }
        decimal Price { get; }
    }
}
