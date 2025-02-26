
using Microsoft.EntityFrameworkCore;
using ShopClothing.Domain.Entities.Order;
using ShopClothing.Domain.Interface.Order;
using ShopClothing.Infrastructure.Data;

namespace ShopClothing.Infrastructure.Repositories.Order
{
    public class OrderRepository(AppDbContext context) : IOrderRepository
    {
        public async Task<Orders> GetOrderByTransactionID(Guid transactionID)
        {
            var order = await context.Orders
                                     .Include(o => o.Details)
                                     .Where(o => o.TransactionID == transactionID)
                                     .FirstOrDefaultAsync();

            if (order is null)
                return null!; 
            return order;
        }
    }
}
