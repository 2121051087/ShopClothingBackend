
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Cart.CartItem;

namespace ShopClothing.Application.Services.Interfaces.Basket
{
    public interface ICartItemService
    {
        Task<IEnumerable<GetCartItem>> GetAllAsync();
        Task<GetCartItem> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateCartItem item);
        Task<ServiceResponse> UpdateAsync(UpdateCartItem item);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
