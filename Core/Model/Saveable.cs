namespace Core;

public interface ISaveable
{
    public int? Id { get; }
    public bool IsNew { get; }
    public abstract bool IsValid { get; }
}

public abstract class Saveable : ISaveable, IValidatable
{
    public int? Id { get; protected set; }
    public bool IsNew => Id is null;
    public abstract bool IsValid { get; }
}
