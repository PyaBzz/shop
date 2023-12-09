namespace Core;

public class OrderFakeRepo : Order.RepositoryConcept
{
    public Task<int> Save(Order.State x)
    {
        int nextId;
        var isSuccess = false;
        do
        {
            nextId = data.Count;
            isSuccess = data.TryAdd(nextId, x);
        }
        while (isSuccess == false);
        return Task.FromResult(nextId);
    }

    public Task<Order.State> Get(int id)
    {
        if (data.ContainsKey(id))
            return Task.FromResult(data[id]);
        return Task.FromResult<Order.State>(default);
    }

    // ==============================  Internal Logic  ==============================

    private readonly ConcurrentDictionary<int, Order.State> data = new();

}
