namespace Core;

public interface ProductConcept
{
    int? Id { get; }
    string Name { get; set; }
    decimal Price { get; set; }
    DateTime ReleaseDate { get; set; }
}

public class Product : ProductConcept
{
    #region ==============================  Interface  ==============================

    public int? Id { get; private set; }

    [Required]
    public string Name { get; set; }

    public decimal Price { get; set; }

    [PastDate]
    public DateTime ReleaseDate { get; set; }

    #endregion
    #region ==============================  Factory  ==============================

    public Product(State state)
    {
        // id cannot be assigned in the ctor !
        Name = state.Name;
        Price = state.Price;
        ReleaseDate = state.ReleaseDate;
    }

    public Task<int> Save(RepositoryConcept repo)
    {
        var state = GetState();
        return repo.Save(state);
    }

    public static async Task<Product> Get(RepositoryConcept repo, int id)
    {
        var state = await repo.Get(id);
        Product instance = new(state);
        instance.Id = state.Id;
        return instance;
    }

    #endregion
    #region ==============================  State  ==============================

    public class State
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    private State GetState() => new()
    {
        Id = Id,
        Name = Name,
        Price = Price,
        ReleaseDate = ReleaseDate
    };

    #endregion
    #region ==============================  Internal Logic  ==============================

    #endregion
    #region ==============================  Dependencies  ==============================

    public interface RepositoryConcept
    {
        Task<int> Save(State state);
        Task<State> Get(int id);
        //Task<State> Get(int[] ids);
    }

    #endregion
}
