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

    public Product(string name, decimal price, DateTime releaseDate, int? id = null)
    {
        Id = id;
        Name = name;
        Price = price;
        ReleaseDate = releaseDate;
    }

    #endregion
    #region ==============================  Internal Logic  ==============================

    #endregion
}

#region ==============================  Dependencies  ==============================

public interface ProductRepoConcept
{
    Task<int> Save(ProductConcept product);
    Task<ProductConcept> Get(int id);
    Task<ProductConcept[]> Get(int[] ids);
}

#endregion
