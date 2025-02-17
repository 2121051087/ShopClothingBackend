using ShopClothing.Domain.Entities.Product;
using System.Text.Json.Serialization;

namespace ShopClothing.Domain.Entities.Cart
{
    public class CartItems
    {
        public Guid CartItemID { get; set; }
        public Guid CartID { get; set; }
        public Guid ProductID { get; set; }
        public Guid Product_AttributeID { get; set; }
        public int QuantityBasket { get; set; } = 1;


        [JsonIgnore]
        public Products? Products { get; set; }
        [JsonIgnore]
        public Product_Attributes? Product_Attributes { get; set; }
        [JsonIgnore]
        public Carts? Carts { get; set; }


    }
    
}
