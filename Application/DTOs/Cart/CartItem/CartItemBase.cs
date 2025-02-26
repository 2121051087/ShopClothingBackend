using ShopClothing.Application.DTOs.Product;
using ShopClothing.Application.DTOs.Product.ProductAttributes;
using System.Text.Json.Serialization;

namespace ShopClothing.Application.DTOs.Cart.CartItem
{
    public class CartItemBase
    {
        public Guid ProductID { get; set; }
        public Guid CartID { get; set; }
        public Guid Product_AttributeID { get; set; }


        public int QuantityBasket { get; set; } = 1;

        
        public GetProduct? GetProduct { get; set; }
        [JsonIgnore]
        public GetProductAttributes? GetProductAttributes { get; set; }
    }
}
