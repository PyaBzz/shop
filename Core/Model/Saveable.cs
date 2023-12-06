namespace Core;

public interface ISaveable
{
    int? Id { get; }
    bool IsNew { get; }
    abstract bool IsValid { get; }
    abstract void Validate();
    Task<int> Save();
}

public abstract class Saveable : ISaveable, IValidatable
{
    public int? Id { get; protected set; }
    public bool IsNew => Id is null;
    public abstract bool IsValid { get; }
    public void Validate()
    {
        if (IsValid is false)
            throw new InvalidOperationException(
                $"The object of type {this.GetType().Name} is in an invalid state for saving"
                );
    }

    public abstract Task<int> Save();

    protected int SetId(int id)
    {
        if (IsNew)
            Id = id;
        return id;
    }
}
