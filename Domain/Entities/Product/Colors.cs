
using System.ComponentModel.DataAnnotations;

namespace ShopClothing.Domain.Entities.Product
{
    public  class Colors
    {
        [Key]
        public Guid ColorID { get; set; }

        public string? ColorName { get; set; }

        public string? ColorHexCode { get; set; }

        public ICollection<Product_Attributes>? Product_Attributes { get; set; }
    }
}
