using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.DTOs.Cart.CartItem;
using ShopClothing.Application.Services.Interfaces.Basket;
using ShopClothing.Application.Services.Interfaces.Cart;
using System.Security.Claims;

namespace ShopClothing.Host.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        private readonly ICartService _cartService;
        private readonly ClaimsPrincipal _user;

        public CartController(ICartItemService cartItemService, ICartService cartService, IHttpContextAccessor httpContextAccessor)
        {
             _cartItemService = cartItemService;
             _cartService = cartService;
             _user = httpContextAccessor.HttpContext!.User;
        }


        [HttpPost("add-item")]
        public async Task<IActionResult> AddItemToCartAsync(CreateCartItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cartItemService.AddAsync(item);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteItemFromCartAsync(Guid id)
        {
            var result = await _cartItemService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetItemFromCartAsync()
        {
            var userId = _user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var result = await _cartService.GetCartAsync(userId);
            return result != null ? Ok(result) : NotFound(result);
        }


        [HttpPut("Update-Item-Quantity")]
        public async Task<IActionResult> UpdateItemQuantityAsync(UpdateCart item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _cartService.UpdateCart(item);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("clear-cart")]
        public async Task<IActionResult> ClearCartAsync()
        {
            var result = await _cartItemService.ClearCartAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

    }
}
