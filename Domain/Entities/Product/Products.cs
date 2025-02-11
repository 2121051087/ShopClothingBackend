
using ShopClothing.Domain.Entities.Category;

namespace ShopClothing.Domain.Entities.Product
{
    public class Products
    {
        public Guid ProductID { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.AddHours(7);

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow.AddHours(7);

        public Guid CategoryID { get; set; }
        public Categories? Categories { get; set; }

        public ICollection<Product_Attributes>? Product_Attributes { get; set; } 
    }
}
