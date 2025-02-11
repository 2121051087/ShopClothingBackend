
using ShopClothing.Domain.Entities.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Domain.Entities.Category
{
    public class Categories
    {
        [Key]
        public  Guid CategoryID { get; set; }

        public string? CategoryName { get; set; }

        public ICollection<Products>? Products = [];
    }
}
