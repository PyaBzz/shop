namespace Core;

public interface OrderConcept
{
    int? Id { get; }
    bool Add(int itemId);
    Task<decimal> Price { get; }
}

public class Order : OrderConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public bool Add(int itemId)
    {
        if (itemIds.Contains(itemId))
            return false;
        itemIds.Add(itemId);
        return true;
    }

    public Task<decimal> Price
        => throw new NotImplementedException();

    #endregion
    #region ==============================  Factory  ==============================

    public Order(State state)
    {
        // id cannot be assigned in the ctor !
        itemIds = new List<int>();
    }

    public static async Task<Order> Retrieve(RepositoryConcept repo, int id)
    {
        var state = await repo.Get(id);
        Order instance = new(state);
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
    }

    private State GetState() => new() { Id = Id };

    #endregion
    #region ==============================  Internal Logic  ==============================

    private List<int> itemIds;

    #endregion
    #region ==============================  Dependencies  ==============================

    public interface RepositoryConcept
    {
        Task<State> Get(int id);
        Task<int> Save(State state);
    }

    #endregion
}
