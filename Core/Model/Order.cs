namespace Core;

public interface OrderConcept
{
    int? Id { get; }
    Task<decimal> Price { get; }
}

public class Order : OrderConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public Task<decimal> Price
        => throw new NotImplementedException();

    #endregion
    #region ==============================  Factory  ==============================

    public Order(int? id = null)
    {
        Id = id;
    }

    #endregion
    #region ==============================  Internal Logic  ==============================


    #endregion
    #region ==============================  Dependencies  ==============================

    public interface RepositoryConcept
    {
        Task<int> Save(OrderConcept order);
        Task<OrderConcept> Get(int id);
        Task<OrderConcept[]> Get(int[] ids);
    }

    #endregion
}
