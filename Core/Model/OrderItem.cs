namespace Core;

public interface OrderItemConcept
{
    int? Id { get; }
    int? OrderId { get; }
    int ProductId { get; }
    int Quantity { get; }
    Task<ProductConcept> GetProduct(ProductRepoConcept repo);
    Task<decimal> GetPrice(ProductRepoConcept repo);
}

public class OrderItem : OrderItemConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public int? OrderId { get; private set; }

    public int ProductId { get; }

    public Task<ProductConcept> GetProduct(ProductRepoConcept repo)
        => repo.Get(ProductId);

    public int Quantity { get; set; }

    public async Task<decimal> GetPrice(ProductRepoConcept repo)
        => Quantity * (await GetProduct(repo)).Price;

    #endregion
    #region ==============================  Factory  ==============================

    public OrderItem(int orderId, int productId, int quantity, int? id = null)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
        Id = id;
    }

    #endregion
    #region ==============================  Internal Logic  ==============================

    #endregion
}

#region ==============================  Dependencies  ==============================

public interface OrderItemRepoConcept
{
    Task<int> Save(OrderItemConcept orderItem);
    Task<OrderItemConcept> Get(int id);
    Task<OrderItemConcept[]> Get(int[] ids);
    Task<OrderItemConcept[]> GetForOrder(int orderId);
}

#endregion
