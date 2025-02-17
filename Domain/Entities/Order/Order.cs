

using ShopClothing.Domain.Entities.Payment;

namespace ShopClothing.Domain.Entities.Order
{
    public class Order
    {
        public Guid OrderID { get; set; }

        public Guid UserID { get; set; }

        public decimal TotalAmount { get; set; }

        public string OrderStatus { get; set; } = "Pending";

        public DateTime OrderDate { get; set; }

        public Guid PaymentMethodID { get; set; }

        public Guid? TransactionID { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string DeliveryPhone { get; set; } = null!;


        public ICollection<OrderDetails> Details { get; set; } = new List<OrderDetails>();

        public PaymentMethod PaymentMethod { get; set; } = null!;

        public Transactions Transaction { get; set; } = null!;

    }
}
