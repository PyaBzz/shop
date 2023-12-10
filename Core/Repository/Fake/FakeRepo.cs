namespace Core;

public class FakeRepo<T>
{
    #region ==============================  Interface  ==============================

    public Task<int> Save(T x)
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

    public Task<T> Get(int id)
    {
        if (data.ContainsKey(id))
            return Task.FromResult(data[id]);
        return Task.FromResult<T>(default);
    }

    #endregion
    #region ==============================  Internal Logic  ==============================

    private readonly ConcurrentDictionary<int, T> data = new();

    #endregion
}
