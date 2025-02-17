

using ShopClothing.Domain.Entities.Product;

namespace ShopClothing.Domain.Entities.Order
{
    public class OrderDetails
    {
        public Guid OrderDetailID { get; set; }

        public Guid OrderID { get; set; }

        public Guid ProductID { get; set; }

        public Guid Product_AttributeID { get; set; }

        public int QuantityBasket { get; set; } = 1;

        public decimal Price { get; set; }


        public Products? Products { get; set; }

        public Order? Order { get; set; }

        public Product_Attributes? Product_Attributes { get; set; } 


    }
}
