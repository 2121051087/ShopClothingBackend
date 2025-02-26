
using AutoMapper;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Cart;
using ShopClothing.Application.DTOs.Cart.CartItem;
using ShopClothing.Application.DTOs.Product;
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
     

        public async Task<GetCart> GetCartAsync(string userId)
        {
            var cart = await cartRepository.GetOrCreateCartAsync(userId);
            if (cart == null) return null!;

            var getCart = mapper.Map<GetCart>(cart);

            getCart.CartItems = cart.CartItems.Select(
                item =>
                {
                    var getCartItem = mapper.Map<GetCartItem>(item);
                    getCartItem.GetProduct = mapper.Map<GetProduct>(item.Products);
                    return getCartItem;
                }
            ).ToList();

            return getCart;
        }

        public async Task<ServiceResponse> UpdateCart(UpdateCart updateCart)
        {
            var cart = await cartRepository.GetExistCartItems(updateCart.CartID);
            if (cart == null) return new ServiceResponse(false, "Cart items not found");

            foreach (var item in updateCart.cartItems)
            {
                var cartItem = cart.CartItems.FirstOrDefault(x => x.CartItemID == item.CartItemID);
                if (cartItem == null) return new ServiceResponse(false, "Cart item not found");
                cartItem.QuantityBasket = item.QuantityBasket;
            }

            await CartInterface.UpdateAsync(cart);
            return new ServiceResponse(true, "Cart updated successfully");
        }
    }
}
