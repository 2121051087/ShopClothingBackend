using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.DTOs.Cart.CartItem;
using ShopClothing.Application.Services.Interfaces.Basket;
using ShopClothing.Application.Services.Interfaces.Cart;

namespace ShopClothing.Host.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartItemService cartItemService,ICartService cartService) : ControllerBase
    {
        [HttpPost("add-item")]
        public async Task<IActionResult> AddItemToCartAsync(CreateCartItem item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await cartItemService.AddAsync(item);

            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> DeleteItemFromCartAsync(Guid id)
        {
            var result = await cartItemService.DeleteAsync(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("all/{userID}")]
        public async Task<IActionResult>  GetItemFromCartAsync(string userID)
        {
            var result = await cartService.GetCartAsync(userID);
            return result != null ? Ok(result) : NotFound(result);
        } 
    }
}
