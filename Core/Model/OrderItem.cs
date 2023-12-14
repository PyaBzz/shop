namespace Core;

public interface OrderItemConcept
{
    int? Id { get; }
    int ProductId { get; }
    Task<ProductConcept> GetProduct(ProductRepoConcept repo);
    int Quantity { get; }
    Task<decimal> GetPrice(ProductRepoConcept repo);
}

public class OrderItem : OrderItemConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    public int ProductId { get; }

    public Task<ProductConcept> GetProduct(ProductRepoConcept repo)
        => repo.Get(ProductId);

    public int Quantity { get; set; }

    public async Task<decimal> GetPrice(ProductRepoConcept repo)
        => Quantity * (await GetProduct(repo)).Price;

    #endregion
    #region ==============================  Factory  ==============================

    public OrderItem(int productId, int quantity, int? id = null)
    {
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
}

#endregion
