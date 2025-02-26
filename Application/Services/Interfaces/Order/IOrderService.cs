using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Order;

namespace ShopClothing.Application.Services.Interfaces.Order
{
    public interface IOrderService
    {
        Task<ServiceResponse> CreateOrderCashOnDeliveryAsync(CreateOrder order);

        Task<(string ApprovalUrl, Guid TransactionID)> CreateOrderAsyncWithPayPal(CreateOrder order);

        Task<ServiceResponse> ConfirmPayPalPayment(Guid transactionId);

        Task<ServiceResponse> PayPalReturn( string token, string PayerID);


    }
}
