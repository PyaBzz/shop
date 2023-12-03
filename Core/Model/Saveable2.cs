namespace Core;

public interface IRepository //todo: Should this be generic?
{
    Task<int> Store(object x);
    Task<object> Get(int id);
}

public abstract class Saveable2
{
    private IRepository repo;

    public Saveable2(IRepository r)
        => repo = r;

    public int? Id { get; protected set; }
    public bool IsNew => Id is null;

    /// <summary>
    /// Validates, then stores the object in a data store
    /// </summary>
    /// <returns></returns>
    public async Task<int> Save()
    {
        if (IsValid is false)
            throw new InvalidOperationException($"The object of type {GetType().Name} failed state validation prior to saving");
        var id = await repo.Store(this);
        if (IsNew)
            Id = id;
        return id;
    }

    /// <summary>
    /// Validates the state of this object from a business perspective
    /// </summary>
    /// <returns></returns>
    public abstract bool IsValid { get; }

    /// <summary>
    /// Stores the object in a data store e.g an SQL database
    /// </summary>
    /// <returns></returns>
    //public abstract Task<int> Store();
}
