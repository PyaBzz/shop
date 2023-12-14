namespace Core;

public class OrderItemFakeRepo : FakeRepo<OrderItemConcept>, OrderItemRepoConcept
{
    public Task<OrderItemConcept[]> GetForOrder(int orderId)
    {
        var items = data.Values.Where(x => x.OrderId == orderId);
        return Task.FromResult(items.ToArray());
    }
}
