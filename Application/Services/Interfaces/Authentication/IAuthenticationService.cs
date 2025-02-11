using ShopClothing.Application.DTOs;
using ShopClothing.Application.DTOs.Identity;


namespace ShopClothing.Application.Services.Interfaces.Authentication
{
   public  interface IAuthenticationService
    {
        Task<ServiceResponse> Register(RegisterUser registerUser);

        Task<LoginResponse> Login(LoginUser loginUser);

        Task<LoginResponse> ReviveToken( string refreshToken);
    }
}
