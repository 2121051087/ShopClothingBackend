

namespace ShopClothing.Application.Services.Interfaces.PayPal
{
    public interface IPayPalService
    {
        Task<(string ApprovalUrl, string OrderID)> CreatePaymentAsync(decimal amount);

        Task<bool> CapturePaymentAsync(string paymentId);

    }
}
