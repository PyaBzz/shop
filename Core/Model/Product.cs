using Baz.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public interface IProduct
    {
        int? Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        DateTime ReleaseDate { get; set; }
    }

    public class Product : IProduct
    {
        // ==============================  Interface  ==============================

        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [PastDate]
        public DateTime ReleaseDate { get; set; }

        // ==============================  State  ==============================

        // ==============================  Factory  ==============================

        public Product(string name, decimal price, DateTime releaseDate, int? id = default)
        {
            Name = name;
            Price = price;
            ReleaseDate = releaseDate;
            Id = id;
        }
    }
}
