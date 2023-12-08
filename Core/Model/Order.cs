namespace Core;

public interface IOrder
{
    bool Add(IOrderItem item);
    ImmutableDictionary<int, IOrderItem> Items { get; }
    decimal Price { get; }
    Task<int> Stage();
}

public class Order : Saveable, IOrder
{
    // ==============================  Interface  ==============================

    public ImmutableDictionary<int, IOrderItem> Items
        => items.ToImmutableDictionary();

    public bool Add(IOrderItem item)
    {
        if (items.ContainsKey(item.ProductId))
            return false;
        items.Add(item.ProductId, item);
        return true;
    }

    public decimal Price
        => throw new NotImplementedException();

    public Task<int> Stage() => Save();

    public override bool IsValid => true;

    public override async Task<int> Save()
    {
        Validate();
        var id = await repo.Save(this);
        return SetId(id);
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

    // private stuff
}
