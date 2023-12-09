﻿namespace Core;

public interface IOrderItem
{
    int? Id { get; }
    int ProductId { get; }
    Task<IProduct> Product { get; }
    int Quantity { get; }
    Task<decimal> Price { get; }
}

public class OrderItem : IOrderItem
{
    // ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public int ProductId { get; }

    public Task<IProduct> Product //Reads from datastore based on ProductId
        => throw new NotImplementedException();

    public int Quantity { get; set; }

    public Task<decimal> Price //Reads from product
        => throw new NotImplementedException();

    // ==============================  Factory  ==============================

    public OrderItem(State state)
    {
        // id cannot be assigned in the ctor !
        ProductId = state.ProductId;
        Quantity = state.Quantity;
    }

    public static async Task<OrderItem> Retrieve(RepositoryConcept repo, int id)
    {
        var state = await repo.Get(id);
        OrderItem instance = new(state);
        instance.Id = state.Id;
        return instance;
    }

    public Task<int> Save(RepositoryConcept repo)
    {
        State state = new() { Id = Id, ProductId = ProductId, Quantity = Quantity };
        return repo.Save(state);
    }

    // ==============================  State  ==============================

    public class State
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public interface RepositoryConcept
    {
        Task<State> Get(int id);
        Task<int> Save(State state);
    }
}
