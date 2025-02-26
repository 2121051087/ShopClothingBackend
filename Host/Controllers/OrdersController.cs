
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.DTOs.Order;
using ShopClothing.Application.Services.Interfaces.Basket;
using ShopClothing.Application.Services.Interfaces.Cart;
using ShopClothing.Application.Services.Interfaces.Order;
using ShopClothing.Application.Services.Interfaces.PayPal;
using System.Security.Claims;

namespace ShopClothing.Host.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ClaimsPrincipal _user;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;


        public OrdersController(IOrderService orderService, ICartService cartService,
          ICartItemService cartItemService, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _user = httpContextAccessor.HttpContext!.User;
            _cartService = cartService;
            _cartItemService = cartItemService;

        }
        private string GetUserId()
        {
            return _user.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }

        [HttpPost("add-Cash-on-Delivery")]
        public async Task<IActionResult> AddOrderAsync(CreateOrder order)
        {

            var userId = GetUserId();
            order.UserID = userId!;

            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _orderService.CreateOrderCashOnDeliveryAsync(order);

            await _cartItemService.ClearCartAsync();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add-PayPal")]
        public async Task<IActionResult> CreateOrderWithPayPal([FromBody] CreateOrder order)
        {
            var userId = GetUserId();
            order.UserID = userId!;
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var (approvalUrl, transactionId) = await _orderService.CreateOrderAsyncWithPayPal(order);
            if (string.IsNullOrEmpty(approvalUrl)) return BadRequest("Failed to create PayPal payment");


            await _cartItemService.ClearCartAsync();

            return Ok(new { ApprovalUrl = approvalUrl, TransactionID = transactionId });
        }

        [HttpGet("confirm-payment/{transactionId}")]
        public async Task<IActionResult> ConfirmPayPalPayment(Guid transactionId)
        {
            var result = await _orderService.ConfirmPayPalPayment(transactionId);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Message);
        }


        [HttpGet("return")]
        public async Task<IActionResult> PayPalReturn( string token, string PayerID)
        {
            var result = await _orderService.PayPalReturn( token, PayerID);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result.Message);
        }

    }
}
