namespace Core
{
    public abstract class Saveable : IValidatable
    {
        public int? Id { get; protected set; }
        public bool IsNew => Id is null;
        public abstract bool IsValid { get; }
    }
}
