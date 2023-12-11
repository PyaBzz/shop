using System.Xml.Linq;

namespace Core;

public interface OrderItemConcept
{
    int? Id { get; }
    int ProductId { get; }
    Task<Product> GetProduct(Product.RepositoryConcept repo);
    int Quantity { get; }
    Task<decimal> Price { get; }
}

public class OrderItem : OrderItemConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public int ProductId { get; }

    public Task<Product> GetProduct(Product.RepositoryConcept repo)
        => throw new NotImplementedException();

    public int Quantity { get; set; }

    public Task<decimal> Price //Reads from product
        => throw new NotImplementedException();

    #endregion
    #region ==============================  Factory  ==============================

    public OrderItem(State state)
    {
        // id cannot be assigned in the ctor !
        ProductId = state.ProductId;
        Quantity = state.Quantity;
    }

    public static async Task<OrderItem> Get(RepositoryConcept repo, int id)
    {
        var state = await repo.Get(id);
        OrderItem instance = new(state);
        instance.Id = state.Id;
        return instance;
    }

    public Task<int> Save(RepositoryConcept repo)
    {
        var state = GetState();
        return repo.Save(state);
    }

    #endregion
    #region ==============================  State  ==============================

    public class State
    {
        public int? Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    private State GetState() => new()
    {
        Id = Id,
        ProductId = ProductId,
        Quantity = Quantity
    };

    #endregion
    #region ==============================  Internal Logic  ==============================

    #endregion
    #region ==============================  Dependencies  ==============================

    public interface RepositoryConcept
    {
        Task<State> Get(int id);
        Task<int> Save(State state);
    }

    #endregion
}
