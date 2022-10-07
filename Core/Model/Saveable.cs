namespace Core
{
    public abstract class Saveable
    {
        public int? Id { get; protected set; }
        public bool IsNew => Id == null;
    }
}
