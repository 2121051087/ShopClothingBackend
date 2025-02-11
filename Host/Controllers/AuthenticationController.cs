
using Microsoft.AspNetCore.Mvc;
using ShopClothing.Application.DTOs.Identity;
using ShopClothing.Application.Services.Interfaces.Authentication;
using System.Net;


namespace ShopClothing.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            var result = await authenticationService.Register(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUser user)
        {
            var result = await authenticationService.Login(user);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("refreshToken/{refreshToken}")]
       
        public async Task<IActionResult> ReviveToken(string refreshToken)
        {
            //string encodedToken = WebUtility.UrlEncode(refreshToken); // Encode lại token
            var result = await authenticationService.ReviveToken(refreshToken);
            return result.Success ? Ok(result) : BadRequest(result);
        }


    }
}
