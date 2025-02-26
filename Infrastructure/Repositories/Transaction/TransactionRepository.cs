
using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Payment;
using ShopClothing.Domain.Interface.Transaction;
using ShopClothing.Infrastructure.Data;

namespace ShopClothing.Infrastructure.Repositories.Transaction
{
    public class TransactionRepository(AppDbContext context) : ITransactionRepository
    {
        public async Task<Transactions> GetTransactionByPaymentID(string orderId)
        {
            var transaction = await context.Transactions
                                   .Where(Transactions => Transactions.PaymentReference == orderId)
                                   .FirstOrDefaultAsync();

            if (transaction is null)
                return null!;
            return transaction;
        }
    }
  
}

