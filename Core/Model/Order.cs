namespace Core
{
    public interface IOrder
    {
        bool Add(IOrderItem item);
        IOrderItem[] Items { get; } //todo: make it ImmutableDictionary
        decimal Price { get; }
        Task<int> Stage();
    }

    public class Order : Saveable, IOrder
    {
        // ==============================  Interface  ==============================
        public IOrderItem[] Items => items.Values.ToArray();
        public bool Add(IOrderItem item)
        {
            if (items.ContainsKey(item.ProductId))
                return false;
            items.Add(item.ProductId, item);
            return true;
        }
        public decimal Price => items.Values.Sum(x => x.Price);
        public async Task<int> Stage()
        {
            var id = await repo.Save(this);
            if (IsNew)
                Id = id;
            return id;
        }

        // ==============================  State  ==============================
        private Dictionary<int, IOrderItem> items;
        private IOrderRepo repo;

        // ==============================  Factory  ==============================
        public Order(IOrderRepo r)
        {
            items = new Dictionary<int, IOrderItem>();
            repo = r;
        }

        public Order(Dictionary<int, IOrderItem> itmz, int? id)
        {
            items = itmz;
            Id = id;
        }

        // ==============================  Internal Logic  ==============================
        // mostly private stuff
    }
}
