using ShopClothing.Application.DTOs.Product.ProductAttributes;

namespace ShopClothing.Application.DTOs.Product
{
    public class GetProduct : ProductBase
    {
        public Guid ProductID { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<GetProductAttributes> GetProductAttributes { get; set; } = [];
    }
}
