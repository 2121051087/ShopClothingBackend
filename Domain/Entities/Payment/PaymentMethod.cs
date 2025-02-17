namespace ShopClothing.Domain.Entities.Payment
{
    public class PaymentMethod
    {
        public Guid PaymentMethodID { get; set; }
        public string PaymentMethodName { get; set; } = null!;
        
    }
}
