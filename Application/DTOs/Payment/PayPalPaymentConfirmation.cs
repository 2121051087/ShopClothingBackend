
namespace ShopClothing.Application.DTOs.Payment
{
    public class PayPalPaymentConfirmation
    {
        public string Status { get; set; } = null!;
        public string Token { get; set; } = null!;
        public string PayerID { get; set; } = null!;
    }
}
