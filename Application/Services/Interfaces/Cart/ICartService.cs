

using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Cart;
using ShopClothing.Application.DTOs.Cart.CartItem;

namespace ShopClothing.Application.Services.Interfaces.Cart
{
    public interface ICartService
    {
     
        Task<GetCart> GetCartAsync(string userId);
        Task<ServiceResponse> UpdateCart(UpdateCart updateCart);
    }
}
