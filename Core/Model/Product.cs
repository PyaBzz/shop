namespace Core;

public interface IProduct
{
    int? Id { get; }
    string Name { get; set; }
    decimal Price { get; set; }
    DateTime ReleaseDate { get; set; }
}

public class Product : IProduct
{
    // ==============================  Interface  ==============================

    public int? Id { get; private set; }

    [Required]
    public string Name { get; set; }

    public decimal Price { get; set; }

    [PastDate]
    public DateTime ReleaseDate { get; set; }

    // ==============================  Factory  ==============================

    public Product(State state)
    {
        // id cannot be assigned in the ctor !
        Name = state.Name;
        Price = state.Price;
        ReleaseDate = state.ReleaseDate;
    }

    public static async Task<Product> Retrieve(RepositoryConcept repo, int id)
    {
        var state = await repo.Get(id);
        Product instance = new(state);
        instance.Id = state.Id;
        return instance;
    }

    public Task<int> Save(RepositoryConcept repo)
    {
        State state = new() { Id = Id, Name = Name, Price = Price, ReleaseDate = ReleaseDate };
        return repo.Save(state);
    }

    // ==============================  State  ==============================

    public class State
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public interface RepositoryConcept
    {
        Task<State> Get(int id);
        Task<int> Save(State state);
    }
}
