

using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Cart;

namespace ShopClothing.Application.Services.Interfaces.Cart
{
    public interface ICartService
    {
      
        Task<ServiceResponse> ClearCartAsync(string userId);
        Task<GetCart> GetCartAsync(string userId);
    }
}
