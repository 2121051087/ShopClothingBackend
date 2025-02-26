

using ShopClothing.Domain.Entities.Order;

namespace ShopClothing.Domain.Interface.Order
{
    public interface IOrderRepository
    {
        Task<Orders> GetOrderByTransactionID(Guid transactionID);
    }
}
