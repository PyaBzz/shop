namespace Core;

public interface OrderConcept
{
    int? Id { get; }
    Task<decimal> GetPrice(
        OrderItemRepoConcept itemRepo,
        ProductRepoConcept prodRepo
        );
}

public class Order : OrderConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public async Task<decimal> GetPrice(
        OrderItemRepoConcept itemRepo,
        ProductRepoConcept prodRepo
        )
    {
        var items = await itemRepo.GetForOrder(Id.Value);
        var prices = items
            .Select(async x => await x.GetPrice(prodRepo))
            .Select(x => x.Result);
        return prices.Sum();
    }

    #endregion
    #region ==============================  Factory  ==============================

    public Order(int? id = null)
    {
        Id = id;
    }

    #endregion
    #region ==============================  Internal Logic  ==============================

    #endregion
}

#region ==============================  Dependencies  ==============================

public interface OrderRepoConcept
{
    Task<int> Save(OrderConcept order);
    Task<OrderConcept> Get(int id);
    Task<OrderConcept[]> Get(int[] ids);
}

#endregion
