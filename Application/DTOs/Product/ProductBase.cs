using ShopClothing.Application.DTOs.Product.ProductAttributes;
using ShopClothing.Domain.Entities.Category;
using System.Text.Json.Serialization;


namespace ShopClothing.Application.DTOs.Product
{
    public class ProductBase
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryID { get; set; }

        
    }
}
