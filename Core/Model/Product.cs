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

    public Product(string name, decimal price, DateTime releaseDate)
    {
        Name = name;
        Price = price;
        ReleaseDate = releaseDate;
    }

    public static async Task<Product> Retrieve(ProductRepoConcept repo, int id)
    {
        var state = await repo.Get(id);
        Product instance = new(state.Name, state.Price, state.ReleaseDate);
        instance.Id = id;
        return instance;
    }

    public async Task<int> Save(ProductRepoConcept repo)
    {
        State state = new() { Id = Id, Name = Name, Price = Price, ReleaseDate = ReleaseDate };
        return await repo.Save(state);
    }

    // ==============================  State  ==============================

    public class State
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}

public interface ProductRepoConcept
{
    Task<Product.State> Get(int id);
    Task<int> Save(Product.State state);
}
