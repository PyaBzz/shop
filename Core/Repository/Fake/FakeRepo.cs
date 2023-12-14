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

    public Task<T[]> Get(int[] ids)
    {
        var existingIds = ids.Where(id => data.ContainsKey(id));
        var items = existingIds
            .Select(id => data[id])
            .ToArray();
        return Task.FromResult(items);
    }

    #endregion
    #region ==============================  Internal Logic  ==============================

    protected readonly ConcurrentDictionary<int, T> data = new();

    #endregion
}
