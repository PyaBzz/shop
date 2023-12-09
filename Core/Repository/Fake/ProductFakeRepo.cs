namespace Core;

public class ProductFakeRepo : Product.RepositoryConcept
{
    // ==============================  Interface  ==============================

    public Task<Product.State> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Save(Product.State state)
    {
        throw new NotImplementedException();
    }

    // ==============================  Internal Logic  ==============================

}
