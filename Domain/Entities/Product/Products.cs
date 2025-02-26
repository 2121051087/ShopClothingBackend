using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Entities.Category;
using ShopClothing.Domain.Entities.Order;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopClothing.Domain.Entities.Product
{
    public class Products
    {
        public Guid ProductID { get; set; }

        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime UpdatedAt { get; set; } 


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public Guid CategoryID { get; set; }

       
        public Categories? Categories { get; set; }

        public ICollection<CartItems>? CartItems { get; set; } 

        public ICollection<Product_Attributes>? Product_Attributes { get; set; } 

        public ICollection<OrderDetails>? OrderDetails { get; set; }
    }
}
