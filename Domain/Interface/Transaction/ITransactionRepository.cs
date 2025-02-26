using ShopClothing.Domain.Entities.Payment;

namespace ShopClothing.Domain.Interface.Transaction
{
    public interface ITransactionRepository
    {
        Task<Transactions> GetTransactionByPaymentID(string orderId);
    }
}
