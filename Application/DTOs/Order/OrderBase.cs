namespace ShopClothing.Application.DTOs.Order
{
    public class OrderBase
    {
        public decimal? TotalAmount { get; set; }

        public string? OrderStatus { get; set; } 

        public Guid PaymentMethodID { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string DeliveryPhone { get; set; } = null!;
    }
}
