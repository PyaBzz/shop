﻿namespace Core;

public class OrderItemFakeRepo : OrderItem.RepositoryConcept
{
    // ==============================  Interface  ==============================

    public Task<OrderItem.State> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Save(OrderItem.State state)
    {
        throw new NotImplementedException();
    }

    // ==============================  Internal Logic  ==============================

}
