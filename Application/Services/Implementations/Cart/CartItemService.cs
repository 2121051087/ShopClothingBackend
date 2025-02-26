using AutoMapper;
using Microsoft.AspNetCore.Http;
using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Cart.CartItem;
using ShopClothing.Application.Services.Interfaces.Basket;
using ShopClothing.Domain.Entities.Cart;
using ShopClothing.Domain.Interface;
using ShopClothing.Domain.Interface.Cart;
using System.Security.Claims;

namespace ShopClothing.Application.Services.Implementations.Cart
{
    public class CartItemService : ICartItemService
    {
        private readonly ClaimsPrincipal? _user;
        private readonly IGeneric<CartItems> _cartItemInterface;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartItemService(IGeneric<CartItems> cartItemInterface, ICartRepository cartRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _cartItemInterface = cartItemInterface;
            _cartRepository = cartRepository;
            _mapper = mapper;
            _user = httpContextAccessor.HttpContext?.User;
        }

        public async Task<ServiceResponse> AddAsync(CreateCartItem item)
        {
            var UserIdClaims = _user?.FindFirst(ClaimTypes.NameIdentifier);
            var userId = UserIdClaims?.Value; // Get the user id from the claims

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }


            var cart = await _cartRepository.GetOrCreateCartAsync(userId);
            item.CartID = cart.CartID;

            if (!CheckQuantityStock(item))
            {
                return new ServiceResponse { Success = false, Message = "Quantity is not available" };
            }
            var mappedItem = _mapper.Map<CartItems>(item);
            int result = await _cartItemInterface.AddAsync(mappedItem);
            return result > 0 ? new ServiceResponse(true, "Item Added  Successfully")
                              : new ServiceResponse(false, "Item Not Added");
        }

        private bool CheckQuantityStock(CreateCartItem item)
        {
            var quantity = _cartRepository.QuantityProductAttributesStock(item.Product_AttributeID);
            return quantity >= item.QuantityBasket;
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await _cartItemInterface.DeleteAsync(id);

            return  result > 0 ? new ServiceResponse(true, "Item Deleted Successfully")
                               : new ServiceResponse(false, "Item Not Deleted");
        }

        public async Task<IEnumerable<GetCartItem>> GetAllAsync()
        {
            var Data = await _cartItemInterface.GetAllAsync();
            if (!Data.Any()) return [];

            return _mapper.Map<IEnumerable<GetCartItem>>(Data);
        }

        public async Task<GetCartItem> GetByIdAsync(Guid id)
        {
            var data = await _cartItemInterface.GetByIdAsync(id);
            if (data == null) return null!;

            return _mapper.Map<GetCartItem>(data);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCartItem item)
        {
            var mappedData = _mapper.Map<CartItems>(item);  
            int result = await _cartItemInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Item Updated Successfully")
                              : new ServiceResponse(false, "Item Not Updated");

        }

        public async Task<ServiceResponse> ClearCartAsync()
        {
            var userId = _user?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            var cart = await _cartRepository.GetOrCreateCartAsync(userId);
            if (cart.CartItems == null || !cart.CartItems.Any())
            {
                return new ServiceResponse(false, "Cart is empty");
            }

            var result = await _cartItemInterface.DeleteRangeAsync(cart.CartItems.ToList());
            return result > 0 ? new ServiceResponse(true, "Items deleted successfully")
                              : new ServiceResponse(false, "Failed to delete items");
        }
    }
}
