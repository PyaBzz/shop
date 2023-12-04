namespace Core;

public interface IOrderRepo
{
    Task<int> Save(Order x);
    Task<Order> Get(int id);
    Task<Order[]> Get();
}
