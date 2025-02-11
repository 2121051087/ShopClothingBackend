
using System.ComponentModel.DataAnnotations;
namespace ShopClothing.Domain.Entities.Product
{
    public class Sizes
    {
        [Key]

        public Guid SizeID { get; set; }

        public string? SizeName { get; set; }

        public ICollection<Product_Attributes>? Product_Attributes { get; set; }
    }
}
