
using AutoMapper;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Cart;
using ShopClothing.Application.DTOs.Cart.CartItem;
using ShopClothing.Application.Services.Interfaces.Basket;
using ShopClothing.Application.Services.Interfaces.Cart;
using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Interface;
using ShopClothing.Domain.Interface.Cart;

namespace ShopClothing.Application.Services.Implementations.Cart
{
    public class CartService(IGeneric<Carts> CartInterface,ICartRepository cartRepository 
        ,ICartItemService cartItemService,IMapper mapper) : ICartService
    {
        public Task<ServiceResponse> ClearCartAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GetCart> GetCartAsync(string userId)
        {
            var cart = await cartRepository.GetOrCreateCartAsync(userId);
            if (cart == null) return null!;

            var getCart = mapper.Map<GetCart>(cart);

            getCart.CartItems = cart.CartItems.Select(item => mapper.Map<GetCartItem>(item)).ToList();

            return getCart;
        }


    }
}
